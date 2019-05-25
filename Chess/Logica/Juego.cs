using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Logica
{
    public class Juego
    {
        public Tablero Tablero{ get; set; }

        public Jugador JugadorLocal { get; set; }
        public Jugador JugadorRemoto { get; set; }

        private IPEndPoint ie;
        private Socket s;
        private Socket sConnect;

        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;

        public bool Blancas { get; set; }
        public string IP_Server { get; set; }
        public int Puerto { get; set; }

        public string MesajeError { get; set; }
        public bool ConexionCancelada { get; set; }

        public void iniciarJuego()
        {
            JugadorLocal = new Jugador(Blancas, true);
            JugadorRemoto = new Jugador(!Blancas, false);
            Tablero = new Tablero(JugadorLocal, JugadorRemoto);
            Tablero.colocarPiezaInicio();
        }

        public string recibirMovimiento()
        {
            try
            {
                return sr.ReadLine();
            }
            catch (IOException)
            {

            }
            catch (ObjectDisposedException)
            {

            }
            return null;
        }

        public void enviarMovimiento(string movimiento)
        {
            sw.WriteLine(movimiento);

            sw.Flush();
        }

        public void cerrarConexion()
        {
            if(sw != null) sw.Close();
            if (sr != null) sr.Close();
            if (ns != null) ns.Close();

            if (sConnect != null) sConnect.Close();
            if (s != null) s.Close(); 
        }

        public bool crearConexionServidor()
        {
            try
            {
                ie = new IPEndPoint(IPAddress.Any, Puerto);

                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                s.Bind(ie);

                IPHostEntry hostInfo = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        IP_Server = ip.ToString();
                }

                return true;
            }
            catch (SocketException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (System.Security.SecurityException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ArgumentNullException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ArgumentException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (IOException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ObjectDisposedException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (InvalidOperationException e) { MesajeError = e.Message; cerrarConexion(); return false; }

        }

        public bool crearServidor()
        {
            ConexionCancelada = false;

            try {     
                s.Listen(1);

                sConnect = s.Accept();

                Console.WriteLine("Aceptado");

                IPEndPoint ieClient = (IPEndPoint)sConnect.RemoteEndPoint;


                ns = new NetworkStream(sConnect);

                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                sw.WriteLine("conectado");
                sw.Flush();

                Console.WriteLine("Escrito");

                string msg = sr.ReadLine();

                Console.WriteLine("Leido {0}", msg);

                if (msg == "unido")
                {
                    if (Blancas)
                    {
                        sw.WriteLine("negras");
                        sw.Flush();
                    }
                    else
                    {
                        sw.WriteLine("blancas");
                        sw.Flush();
                    }
                    Console.WriteLine("Enviado color");
                    return true;
                }
                if (msg == "cancelar")
                {
                    ConexionCancelada = true;
                }
                cerrarConexion();
                return false;
                
            }
            catch (SocketException e) { MesajeError = e.Message; cerrarConexion();  return false; }
            catch (System.Security.SecurityException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ArgumentNullException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ArgumentException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (IOException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ObjectDisposedException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (InvalidOperationException e) { MesajeError = e.Message; cerrarConexion(); return false; }
        }

        public bool crearCliente() 
        {
            try
            {
                ie = new IPEndPoint(IPAddress.Parse(IP_Server), Puerto);

                Console.WriteLine("Dentro - puerto: {0} - blancas {1} - ip {2}", Puerto, Blancas, IP_Server);

                sConnect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                sConnect.Connect(ie);

                Console.WriteLine("Aceptado");

                ns = new NetworkStream(sConnect);

                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                string msg = sr.ReadLine();

                Console.WriteLine("Leido {0}", msg);

                if (msg == "conectado")
                {

                    Console.WriteLine("Dentro conectado");
                    sw.WriteLine("unido");
                    sw.Flush();

                    msg = sr.ReadLine();
                    Console.WriteLine("Recivido color {0}", msg);

                    if (msg == "blancas")
                    {
                        Blancas = true;
                        Console.WriteLine("Recivido color");
                    }
                    if (msg == "negras")
                    {
                        Blancas = false;
                        Console.WriteLine("Recibido color");
                    }
                    return true;
                }
                cerrarConexion();
                return false;
            }
            catch (SocketException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (System.Security.SecurityException e) { MesajeError = e.Message; cerrarConexion(); cerrarConexion(); return false; }
            catch (ArgumentNullException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ArgumentException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (IOException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (ObjectDisposedException e) { MesajeError = e.Message; cerrarConexion(); return false; }
            catch (InvalidOperationException e) { MesajeError = e.Message; cerrarConexion(); return false; }
        }

        public void cancelarConexion()
        {
            try
            {
                IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Puerto);

                Socket sConnect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                sConnect.Connect(ie);

                NetworkStream ns = new NetworkStream(sConnect);

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);

                string msg = sr.ReadLine();

                if (msg == "conectado")
                {

                    sw.WriteLine("cancelar");
                    sw.Flush();

                }
            }
            catch (SocketException) { }
            catch (System.Security.SecurityException) {}
            catch (ArgumentNullException) { }
            catch (ArgumentException) { }
            catch (IOException) {  }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) {  }
            finally
            {
                if (sw != null) sw.Close();
                if (sr != null) sr.Close();
                if (ns != null) ns.Close();
                if (sConnect != null) sConnect.Close();
            }
        }
    }
}
