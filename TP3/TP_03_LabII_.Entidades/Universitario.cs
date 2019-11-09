using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_03_LabII_.ClasesAbstractas
{
    abstract public class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            :base()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Retorna un string con los datos de un Universitario.
        /// </summary>
        /// <returns>Datos de universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder universitario = new StringBuilder();
            universitario.AppendLine(base.ToString());
            universitario.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);
            return universitario.ToString();
        }
        /// <summary>
        /// Verifica si dos Universitarios tienen el mismo DNI o Legajo. Cualquiera de
        /// estas dos coincidencias causa que el retorno sea true.
        /// </summary>
        /// <param name="pg1">Primer universitario.</param>
        /// <param name="pg2">Segundo universitario.</param>
        /// <returns>true si tienen el mismo Legajo o DNI.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Invoca a la sobrecarga de Universitario == Universitario e invierte
        /// el resultado.
        /// </summary>
        /// <param name="pg1">Primer universitario.</param>
        /// <param name="pg2">Segundo universitario.</param>
        /// <returns>true si no tienen el mismo Legajo ni DNI.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Verifica y el objeto a comparar es de tipo Universitario, y si lo es,
        /// verifica si es igual al objeto que llama la funcion.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>true si son iguales, false caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                return (this == (Universitario)obj);
            }
            return false;
        }
        /// <summary>
        /// Este metodo debera entregar la/s clase/s en la que el universitario
        /// participe en formato string.
        /// </summary>
        /// <returns></returns>
        abstract protected string ParticiparEnClase();
    }
}
