using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_laboratorio_2
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero(txtNumero1.Text);
            Numero n2 = new Numero(txtNumero2.Text);            
            string operador = cmbOperador.Text;
            double resultado = Calculadora.Operar(n1, n2, operador);
            lblResultado.Text = resultado.ToString();
            this.btnConvertirABinario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = false;
            string binario = Numero.DecimalBinario(lblResultado.Text);
            lblResultado.Text = binario;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
            string nDecimal = Numero.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = nDecimal;
        }
    }
}
