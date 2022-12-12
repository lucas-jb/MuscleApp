using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Business.MuscleAPI
{
    public class Servidor
    {
        public IPAddress ipAddress;
        public Socket servidor;
        public IPEndPoint localEndPoint;
        Socket conexionCliente;

        public void Init(string direccionIp, int puerto)
        {
            this.ipAddress = IPAddress.Parse(direccionIp);
            this.servidor = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.localEndPoint = new IPEndPoint(ipAddress, puerto);
            servidor.Bind(localEndPoint);
            servidor.Listen(10);
        }
        public void StartServer()
        {
            while (true)
            {
                conexionCliente = servidor.Accept();
                Task.Run(() =>
                {
                    bool endConnection = true;
                    while (endConnection)
                    {
                        Byte[] bytes = new Byte[1024];
                        string datos = null;
                        try
                        {
                            conexionCliente.Receive(bytes);
                            datos = Encoding.ASCII.GetString(bytes);
                        }
                        catch
                        {
                            EndConnection();
                            endConnection = false;
                        }
                    }
                });
            }
        }

        public void EndConnection()
        {
            try
            {
                conexionCliente.Shutdown(SocketShutdown.Both);
                conexionCliente.Close();
            }
            catch
            {

            }
        }
    }
}
