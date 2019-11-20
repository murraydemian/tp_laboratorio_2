using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LabII_TP04_.Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string listaPaquetes = "";
            foreach (Paquete p in ((Correo)elemento).Paquetes)
            {
                listaPaquetes += string.Format("{0} para {1} ({2})", p.TrakingID,
                            p.DireccionEntrega, p.Estado.ToString());
                listaPaquetes += "\n";
            }
            return listaPaquetes;
        }
        /// <summary>
        /// Cierra los hilos en los que se estan ejecutando los paquetes.
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread hiloPaquete in this.mockPaquetes)
            {
                hiloPaquete.Abort();
            }
        }
        /// <summary>
        /// Agrega paquetes a la lista siempre que no sean repetidos y ejecuta su ciclo de
        /// vida en un thread secundario.
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>El correo ingresado con el paquete nuevo.</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    throw new TrackingRepetidoException("El paquete que se intento ingresar " +
                        "ya existe.");
                }
            }
            //Si el paquete no esta repetido, lo agrego a la lista de paquetes.
            c.paquetes.Add(p);

            //Creo un nuevo thread para simular el ciclo de vida del paquete.
            Thread paqueteCicloDeVida = new Thread(p.MockCicloDeVida);

            //Agrego el thread a la lista para poder frenarlo en un futuro.
            c.mockPaquetes.Add(paqueteCicloDeVida);

            //Inicio el thread.
            paqueteCicloDeVida.Start();
            return c;
        }
    }
}
