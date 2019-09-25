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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar()
        {
            this.textBoxNum1.Text = "";
            this.textBoxNum2.Text = "";
            this.labelResultado.Text = "";
            this.comboBoxOperacion.Text = "";
        }
        private static double Operar(string Numero1, string Numero2, string operador)
        {
            double resultado = 0;
            Numero num1 = new Numero(Numero1);
            Numero num2 = new Numero(Numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string numeroUno = this.textBoxNum1.Text;
            string numeroDos = this.textBoxNum2.Text;
            string operador = this.comboBoxOperacion.Text;
            double resultado;
            resultado = Operar(numeroUno, numeroDos, operador);
            this.labelResultado.Text = Convert.ToString(resultado);
        }

        private void BtnConverToBin_Click(object sender, EventArgs e)
        {
            labelResultado.Text = Numero.DecimalBinario(labelResultado.Text);
        }

        private void BtnConverToDec_Click(object sender, EventArgs e)
        {
            labelResultado.Text = Numero.BinarioDecimal(labelResultado.Text);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
