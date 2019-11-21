using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabII_TP04_.Entidades;

namespace LabII_TP04_.Forms
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.lstEstadoEntregado.MouseDown += delegate (object o, MouseEventArgs e)
            {
                if(e.Button == MouseButtons.Right && this.lstEstadoEntregado.SelectedIndex != -1)
                {
                    this.cmsListas.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            };
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += this.paq_InformaEstado;
                this.correo += nuevoPaquete;
            }
            catch(TrackingRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
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
                this.ActualizarEstados(); 
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Clear();
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
            }            
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach(Paquete item in this.correo.Paquetes)
            {
                if(item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(item);
                }
            }
        }
    }
}
