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
namespace Business.APIRest
{
    public static class Servidor
    {
        public static IPAddress ipAddress;
        public static Socket servidor;
        public static IPEndPoint localEndPoint;
        public static Socket conexionCliente;
        public static DataAccessRepository _context = new DataAccessRepository();
        private static JSONConverter _repo;
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
            _repo = new JSONConverter();
            ViewParser.GenerateViews();
            //ipAddress = IPAddress.Parse(GetLocalIPAddress());
            ipAddress = IPAddress.Parse("192.168.1.76");
            servidor = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            localEndPoint = new IPEndPoint(ipAddress, puerto);
            servidor.Bind(localEndPoint);
            servidor.Listen(10);
            SendInfo("Servidor iniciado en la dirección:" + localEndPoint.ToString() + Environment.NewLine);
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
            string[] action;

            if (datos.StartsWith("GET"))
            {
                action = datos.Split("/");
                if (action[1] == "musculos")
                {
                    if (action.Length > 6)
                    {
                        return await _repo.GetEjercicioAsync(action[2]);
                    }
                    return await _repo.GetAllEjerciciosAsync();
                }
            }
            else if (datos.StartsWith("POST"))
            {
                string body = datos.Substring(datos.IndexOf("Content-Length:") + 15);

                string[] aux = body.Split('\n');
                action = datos.Split("/");

                body = aux[2];
                body = body.Substring(0, body.IndexOf('}')+1);
                body.TrimEnd();

                if (action[1] == "musculos")
                {
                    if (action.Length > 6)
                    {
                        return _repo.CreateEjercicio(body);
                    }
                }
            }
            else if (datos.StartsWith("PUT"))
            {
                string body = datos.Substring(datos.IndexOf("Content-Length:") + 15);

                string[] aux = body.Split('\n');
                action = datos.Split("/");

                body = aux[2];
                body = body.Substring(0, body.IndexOf('}') + 1);
                body.TrimEnd();

                if (action[1] == "musculos")
                {
                    if (action.Length > 6)
                    {
                        return _repo.EditEjercicio(body);
                    }
                }
            }
            else if (datos.StartsWith("DELETE"))
            {
                action = datos.Split("/");
                if (action[1] == "musculos")
                {
                    if (action.Length > 6)
                    {
                        _repo.DeleteEjercicio(action[2]);
                    }
                }
            }

            return null;
        }
    }
}