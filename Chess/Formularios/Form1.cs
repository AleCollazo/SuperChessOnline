using Chess.Formularios;
using Logica;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        private Juego juego;
        private FrmEsperandoConexion frmEsperando;

        public Form1(Juego juego)
        {
            InitializeComponent();
            this.juego = juego;
        }
        
        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            FrmNuevaPartida frm = new FrmNuevaPartida();
            DialogResult res = frm.ShowDialog();
            Thread hilo = new Thread(msgBoxInformación);
            hilo.IsBackground = true;
            switch (res)
            {
                case DialogResult.OK:
                    juego.Blancas = frm.rbtBlancas.Checked;
                    try
                    {
                        juego.Puerto = Convert.ToInt32(frm.tbxPuerto.Text);

                        if (juego.crearConexionServidor())
                        {
                            hilo.Start();
                            if (juego.crearServidor())
                            {
                                Program.conexionCorrecta = true;
                                try
                                {
                                    hilo.Abort();
                                }
                                catch (ThreadAbortException) { }
                                this.Close();
                            }
                            else
                            {
                                if (juego.ConexionCancelada)
                                {
                                    MessageBox.Show("Se canceló la conexión",
                                        "Conexión cancelada",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(juego.MesajeError,
                                        "Conexión fallida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(juego.MesajeError,
                                "Conexión fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message, 
                            "Puerto no válido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    
                    break;
                case DialogResult.Cancel:

                    break;
            }
        }
        
        private void btnUnirsePartida_Click(object sender, EventArgs e)
        {
            FrmUnirsePartida frm = new FrmUnirsePartida();
            DialogResult res = frm.ShowDialog();
            switch (res)
            {
                case DialogResult.OK:
                    juego.IP_Server = frm.tbxIP.Text;
                    try
                    {
                        juego.Puerto = Convert.ToInt32(frm.tbxPuerto.Text);
                        if (juego.crearCliente()) {
                            Program.conexionCorrecta = true;
                            this.Close();
                        }
                        else
                        {
                            juego.cerrarConexion();

                            juego.cerrarConexion();
                            MessageBox.Show(juego.MesajeError,
                                "Conexión fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message, 
                            "Puerto no válido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;
                case DialogResult.Cancel:

                    break;
            }
        }

        private void msgBoxInformación()
        {
            
            frmEsperando = new FrmEsperandoConexion();
            frmEsperando.lblIPInfo.Text = string.Format("Dirección IP: {0}", juego.IP_Server);
            frmEsperando.lblPuertoInfo.Text = string.Format("Puerto: {0}", juego.Puerto.ToString());

            DialogResult res = frmEsperando.ShowDialog();
            switch (res)
            {
                case DialogResult.Cancel:
                    juego.cancelarConexion();
                    break;
            }
            
        }
    }
}
