using Data;
using Data.VistasHTML;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Business.MuscleAPI
{
    public static class Servidor
    {
        public static IPAddress ipAddress;
        public static Socket servidor;
        public static IPEndPoint localEndPoint;
        public static Socket conexionCliente;
        public static DataAccessRepository _context = new DataAccessRepository();
        public static void Init(string direccionIp, int puerto)
        {
            ViewParser.GenerateViews();
            ipAddress = IPAddress.Parse(direccionIp);
            servidor = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            localEndPoint = new IPEndPoint(ipAddress, puerto);
            servidor.Bind(localEndPoint);
            servidor.Listen(10);
        }
        public static void StartServer()
        {
            while (true)
            {
                conexionCliente = servidor.Accept();
                Debug.WriteLine("Peticion aceptada");
                Task.Run(() =>
                {
                    Byte[] bytes = new Byte[1024];
                    string datos = null;
                    try
                    {
                        conexionCliente.Receive(bytes);
                        datos = Encoding.ASCII.GetString(bytes);
                        
                        Byte[] respuesta = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK" + Environment.NewLine + Environment.NewLine + OperarDatos(datos));
                        conexionCliente.Send(respuesta);

                        Debug.WriteLine("MENSAJE->" + datos);
                    }
                    catch
                    {
                        Debug.WriteLine("ERROR");
                    }
                    finally
                    {
                        EndConnection();
                    }
                });
            }
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

        public static string OperarDatos(string datos)
        {
            string action = datos.Split('?')[1].Split(' ')[0];
            //string id = action.Split('$')[1];
            string id = "";
            
            if (action.Equals("index"))
            {
                return ViewParser.ReturnView(1);
            }else
            if (action.Equals("getall"))
            {
                string view = ViewParser.ReturnView(2);
                view = view.Replace("@ejercicios", _context.GetAllString());
                return view;
            }else
            if (action.Equals("getbyid$"+id))
            {
                string view = ViewParser.ReturnView(3);
                try
                {
                    view = view.Replace("@ejercicio", _context.GetByIdString(Int32.Parse(id)));
                }
                catch
                {

                }
                
                return view;
            }
            return ViewParser.ReturnView(0);
        }
    }
}