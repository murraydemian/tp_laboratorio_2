using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LabII_TP04_.Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public event DelegadoEstado InformaEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trakingID;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrakingID
        {
            get
            {
                return this.trakingID;
            }
            set
            {
                this.trakingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trakingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trakingID = trakingID;
        }

        public delegate void DelegadoEstado(object source, EventArgs args);

        public void MockCicloDeVida()
        {
            if (this.InformaEstado != null)
            {
                this.estado = EEstado.Ingresado;
                this.InformaEstado(this, EventArgs.Empty);
                Thread.Sleep(4000);
                this.Estado = EEstado.EnViaje;
                this.InformaEstado(this, EventArgs.Empty);
                Thread.Sleep(4000);
                this.Estado = EEstado.Entregado;
                this.InformaEstado(this, EventArgs.Empty);
            }
            else
            {
                throw new Exception("Paquete posee evento pero no manejador");
            }
        }
        
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrakingID,
                        ((Paquete)elemento).DireccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrakingID == p2.TrakingID);
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
