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

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            throw new NotImplementedException();
        }
        public void FinEntregas()
        {

        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    return c;
                }
            }
            c.paquetes.Add(p);
            return c;
        }
    }
}
