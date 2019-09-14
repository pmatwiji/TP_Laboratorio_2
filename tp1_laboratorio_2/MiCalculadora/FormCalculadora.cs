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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            cmbOperador.SelectedItem = "+";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Define que operacion se va a realizar
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operacion deseada</param>
        /// <returns>Resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Deja los espacios por defecto
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = "+";
            this.lblResultado.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numDecimal = new Numero();
            lblResultado.Text = numDecimal.DecimalBinario(this.lblResultado.Text);
            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numBinario = new Numero();
            lblResultado.Text = numBinario.BinarioDecimal(this.lblResultado.Text);
        }
    }
}
