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

        public static void Init(string direccionIp, int puerto)
        {
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
                        OperarDatos(datos);
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

        public static void OperarDatos(string datos)
        {

        }
    }
}
