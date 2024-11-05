using System.IO;
using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cliente
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool responseServer;
        public Form1()
        {
            InitializeComponent();
            ConnectServer();
        }

        private void ConnectServer()
        {
            try
            {
                string server = "127.0.0.1";
                Int32 port = 13000;
                client = new TcpClient(server, port);
                Console.WriteLine("Cliente conectado al servidor");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void EnviarTicket(string ticket)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    Console.WriteLine("Cliente no conectado al servidor");
                    return;
                }

                Byte[] data = Encoding.ASCII.GetBytes(ticket);
                stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Mensaje enviado al servidor: " + ticket);

                // Leer la respuesta del servidor
                Byte[] responseData = new Byte[256];
                Int32 bytes = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.ASCII.GetString(responseData, 0, bytes).Trim();
                responseServer = bool.Parse(response); // Aquí se actualiza la variable de instancia

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }



        private void reservaAccion_Click(object sender, EventArgs e)
        {
            string inputDeLaHora = inputHoraDeReserva.Text;
            //bool estadoDeTicket = servidor.ValidarHora(inputDeLaHora);


            if (inputDeLaHora != null
                //&& estadoDeTicket
                )
            {
                EnviarTicket(inputDeLaHora);


                bool estadoTicket = responseServer;
                if (estadoTicket == true)
                {
                    MessageBox.Show("Reserva realizada en: " + inputDeLaHora);
                }
                else
                {
                    MessageBox.Show("La hora ya fue ocupada o no es una opcion valida");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar una hora de reserva");
            }
        }


        //Liberación de recursos: Se ha añadido un destructor para cerrar el NetworkStream y el TcpClient cuando el objeto Form1 se destruya.
        ~Form1()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
