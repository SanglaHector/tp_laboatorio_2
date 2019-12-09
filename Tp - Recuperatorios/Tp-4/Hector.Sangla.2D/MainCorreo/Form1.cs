using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Entidades.Correo correo;
        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrakingID.Text);
            try
            {
                correo += p;
                p.InformaEstado += new Paquete.DelegadoEstado(Paq_InformaEstado);
                PaqueteDAO.ExceptionDao += new DelegadoException(ErrorDAO);
            }
            catch (TrackingIdRepetidoException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        private void ActualizarEstados()
        {
            lblEstadoEntregado.Items.Clear();
            lblEstadoEnViaje.Items.Clear();
            lblEstadoIngresado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lblEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lblEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lblEstadoEntregado.Items.Add(paquete);
                        break;
                }

            }
        }
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al guardar en archivo");
                }
            }
        }
        private void Paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(this.Paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        private void FrmPal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
        private void ErrorDAO(string msj, Exception ex)
        {
            MessageBox.Show(msj + ex.Message);
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lblEstadoEntregado.SelectedItem);
        }
    }
}
