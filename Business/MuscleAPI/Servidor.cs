using Data;
using Data.VistasHTML;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business.MuscleAPI
{
    public static class Servidor
    {
        public static IPAddress ipAddress;
        public static Socket servidor;
        public static IPEndPoint localEndPoint;
        public static Socket conexionCliente;
        public static DataAccessRepository _context = new DataAccessRepository();
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static void Init(int puerto)
        {
            ViewParser.GenerateViews();
            //ipAddress = IPAddress.Parse(GetLocalIPAddress());
            ipAddress = IPAddress.Parse("192.168.1.76");
            servidor = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            localEndPoint = new IPEndPoint(ipAddress, puerto);
            servidor.Bind(localEndPoint);
            servidor.Listen(10);
            SendInfo("Servidor iniciado en la dirección:"+localEndPoint.ToString()+Environment.NewLine);
        }
        public static void StartServer()
        {
            try
            {
                while (true)
                {
                    conexionCliente = servidor.Accept();
                    SendInfo("Peticion aceptada" + Environment.NewLine);
                    Task.Run(async () =>
                    {
                        byte[] bytes = new byte[1024];
                        string datos = null;
                        try
                        {
                            conexionCliente.Receive(bytes);
                            datos = Encoding.UTF8.GetString(bytes);

                            string text = "HTTP/1.1 200 OK" + Environment.NewLine + Environment.NewLine + await OperarDatos(datos);
                            byte[] respuesta = Encoding.UTF8.GetBytes(text);
                            conexionCliente.Send(respuesta);

                        }
                        catch
                        {
                            SendInfo("ERROR" + Environment.NewLine);
                        }
                        finally
                        {
                            EndConnection();
                        }
                    });
                }
            }
            catch
            {

            }
        }
        public static string SendInfo(string data)
        {
            return data;
        }
        public static void EndConnection()
        {
            bool isClosed = false;
            while (!isClosed)
            {
                try
                {
                    conexionCliente.Shutdown(SocketShutdown.Both);
                    conexionCliente.Close();
                    isClosed = true;
                }
                catch
                {
                    isClosed = false;
                }
            }
        }

        public static async Task<string> OperarDatos(string datos)
        {
            string action;
            try
            {
                action = datos.Split('?')[1].Split(' ')[0];
            }
            catch
            {
                return await ViewParser.ReturnView(0);
            }
            string id = "";
            if (action.Contains("id$"))
            {
                id = action.Split("$")[1];
            }

            if (action.Equals("index"))
            {
                return await ViewParser.ReturnView(1);
            }else
            if (action.Equals("getall"))
            {
                string view = await ViewParser.ReturnView(2);
                view = view.Replace("@ejercicios", _context.GetAllString());
                return view;
            }else
            if(action.Equals("createnew"))
            {
                string view = await ViewParser.ReturnView(7);
                return view;
            }
            if (action.Equals("getbyid$"+id))
            {
                try
                {
                    string view;
                    int intId = Int32.Parse(id);
                    if (_context.Exists(intId))
                    {
                        view = await ViewParser.ReturnView(3);
                        view = view.Replace("@ejercicio", await _context.GetByIdString(Int32.Parse(id)));
                    }
                    else
                    {
                        view = await ViewParser.ReturnView(4);
                        view = view.Replace("@id", id);
                    }
                    return view;
                }
                catch
                {
                    return await ViewParser.ReturnView(0);
                }
            }else
            if (action.Equals("deletebyid$" + id))
            {
                try
                {
                    string view;
                    int intId = Int32.Parse(id);
                    if (_context.Exists(intId))
                    {
                        view = await ViewParser.ReturnView(5);
                        if (_context.DeleteEjercicio(intId))
                        {
                            view = view.Replace("@ejercicio", "Ejercicio con id " + id + " eliminado con exito.");
                        }
                        else
                        {
                            view = view.Replace("@ejercicio", "Ejercicio con id " + id + " no se pudo eliminar.");
                        }
                    }
                    else
                    {
                        view = await ViewParser.ReturnView(4);
                        view = view.Replace("@id", id);
                    }
                    return view;
                }
                catch
                {
                    return await ViewParser.ReturnView(0);
                }
            }else
            if (action.Equals("editbyid$" + id))
            {
                try
                {
                    string view;
                    int intId = Int32.Parse(id);
                    if (_context.Exists(intId))
                    {
                        view = await ViewParser.ReturnView(6);
                        view = view.Replace("@ejercicio", await _context.GetByIdString(Int32.Parse(id)));
                        view = view.Replace("@id", id);
                    }
                    else
                    {
                        view = await ViewParser.ReturnView(4);
                        view = view.Replace("@id", id);
                    }
                    return view;
                }
                catch
                {
                    return await ViewParser.ReturnView(0);
                }
            }
            else
            if(action.Contains("edited")){
                try
                {
                    int editEjercicioId = Int32.Parse(action.Split("$id=")[1].Split('$')[0]);
                    string editEjercicioNombre = action.Split("$nombre=")[1].Split('$')[0];
                    string editEjercicioDescripcion = action.Split("$descripcion=")[1].Split('$')[0];
                    int editEjercicioDificultad = Int32.Parse(action.Split("$dificultad=")[1].Split('$')[0]);
                    bool editEjercicioBasico = (action.Split("$basico=")[1].Split('$')[0]).Equals("True");
                    string editEjercicioMaterialNecesario = action.Split("$materialNecesario=")[1].Split('%')[0];

                    Ejercicio editEjecicio = new()
                    {
                        Id = editEjercicioId,
                        Nombre = editEjercicioNombre,
                        Descripcion = editEjercicioDescripcion,
                        Dificultad = editEjercicioDificultad,
                        Basico = editEjercicioBasico,
                        MaterialNecesario = editEjercicioMaterialNecesario,
                        FechaModificacion = DateTime.Now
                    };
                    _context.EditEjercicio(editEjecicio);
                    string view;
                    view = await ViewParser.ReturnView(3);
                    view = view.Replace("@ejercicio", await _context.GetByIdString(editEjercicioId));
                    return view;
                }
                catch
                {
                    return await ViewParser.ReturnView(0);
                }
            }else
            if(action.Contains("created"))
            {
                try
                {
                    int editEjercicioId = Int32.Parse(action.Split("$id=")[1].Split('$')[0]);
                    string editEjercicioNombre = action.Split("$nombre=")[1].Split('$')[0];
                    string editEjercicioDescripcion = action.Split("$descripcion=")[1].Split('$')[0];
                    int editEjercicioDificultad = Int32.Parse(action.Split("$dificultad=")[1].Split('$')[0]);
                    bool editEjercicioBasico = (action.Split("$basico=")[1].Split('$')[0]).Equals("True");
                    string editEjercicioMaterialNecesario = action.Split("$materialNecesario=")[1].Split('%')[0];

                    Ejercicio editEjecicio = new()
                    {
                        Id = editEjercicioId,
                        Nombre = editEjercicioNombre,
                        Descripcion = editEjercicioDescripcion,
                        Dificultad = editEjercicioDificultad,
                        Basico = editEjercicioBasico,
                        MaterialNecesario = editEjercicioMaterialNecesario,
                        FechaModificacion = DateTime.Now
                    };
                    _context.CreateEjercicio(editEjecicio);
                    string view;
                    view = await ViewParser.ReturnView(3);
                    view = view.Replace("@ejercicio", await _context.GetByIdString(editEjercicioId));
                    return view;
                }
                catch
                {
                    return await ViewParser.ReturnView(0);
                }
            }
            return await ViewParser.ReturnView(0);
        }
    }
}