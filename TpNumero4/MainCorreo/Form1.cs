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
        private Correo correo;
        public Form1()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // crear nuevo paquete asociado
            if (txtDireccion.Text.Length > 0 && txtDireccion.Text.Length < 13 && txtTrakingiD.Text != "000-000-0000")
            {
                Paquete p = new Paquete(this.txtTrakingiD.Text,this.txtDireccion.Text);
                try
                {
                    //correo = correo + p;
                    correo += p;
                    p.InformarEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                }
                catch(TrackingIdRepetidoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            
                this.txtDireccion.Text = "";
                this.txtTrakingiD.Text = "";
            }else
            {
                MessageBox.Show("Campos incompletos");
            }
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        private void ActualizarEstados()
        {
            this.lstBEntregado.Items.Clear();
            this.lstBEnViaje.Items.Clear();
            this.lstBIngresado.Items.Clear();
            foreach (Paquete item in correo.Paquetes)
            {
                switch(item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstBIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstBEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstBEntregado.Items.Add(item);
                        break;
                }
            }
        }
        private void MostrarInformacion<T>(IMostrar<T>elementos)
        {
            if(elementos != null)
            {
                richTextBox1.Text = elementos.MostrarDatos(elementos);
                try
                {
                       this.richTextBox1.Text.Guardar("salida.txt");

                    //foreach (Paquete p in correo.Paquetes)
                    //{
                    //    string salida = String.Format("{0} ({1})", p.ToString(), p.Estado.ToString());
                    //    GuardaString.Guardar(salida, "salida.txt");
                    //}
                }
                catch(Exception ex)
                {   
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstBIngresado.SelectedItem);
        }
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void ContextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstBEntregado.SelectedItem);
        }
    }
}
