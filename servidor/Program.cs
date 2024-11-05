using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Xml;

namespace servidor
{
    internal class Program
    {
        public static string[] horasOcupadas = [];
        static void Main(string[] args)
        {
            Console.WriteLine("···· Soy el servidor ····");
            Arrancar();
        }

        public static void Arrancar()
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(localAddr, 13000);
                server.Start();
                Console.WriteLine("Servidor iniciado y esperando conexiones...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Cliente conectado");

                    NetworkStream stream = client.GetStream();
                    Byte[] bytes = new Byte[256];
                    string data;

                    while (client.Connected)
                    {
                        try
                        {
                            int i = stream.Read(bytes, 0, bytes.Length);
                            if (i == 0) break; // Si no hay datos, se termina la conexión con el cliente

                            data = Encoding.ASCII.GetString(bytes, 0, i).Trim();
                            Console.WriteLine("Mensaje recibido desde el cliente: " + data);

                            bool resultado = ValidaryReservarHora(data);
                            Console.WriteLine("Mensaje enviado al cliente: " + resultado);

                            string response = resultado ? "true" : "false";
                            Byte[] msg = Encoding.ASCII.GetBytes(response);
                            stream.Write(msg, 0, msg.Length);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error procesando mensaje: " + e.Message);
                            break;
                        }
                    }

                    client.Close();
                    Console.WriteLine("Cliente desconectado");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public static bool ValidaryReservarHora(string hora)
        {
            // Validar que la hora no esté ocupada
            Console.WriteLine("Array de horas ocupadas: " + horasOcupadas.Length);
            foreach (var h in horasOcupadas)
            {
                if (h == hora) return false;
            }
            Array.Resize(ref horasOcupadas, horasOcupadas.Length + 1);
            horasOcupadas[horasOcupadas.Length - 1] = hora;

            return true;
        }
    }
}