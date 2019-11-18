using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_03_LabII_.ClasesAbstractas;
using TP_03_LabII_.ClasesInstanciables;

namespace TP_03_LabII_.ClasesInstanciables
{
    

    sealed public class Alumno : Universitario
    {
        #region EEstadoCuenta
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
            :base()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;            
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this (id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna los datos de un alumno es formato string.
        /// </summary>
        /// <returns>Datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder alumno = new StringBuilder();
            alumno.AppendFormat("{0}", base.MostrarDatos());
            alumno.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            alumno.AppendLine(this.ParticiparEnClase());
            return alumno.ToString();
        }
        /// <summary>
        /// Retorna la clase en la que el alumno participa.
        /// </summary>
        /// <returns>Clase que el alumno toma.</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE " + this.claseQueToma);
        }
        /// <summary>
        /// Invoca un metodo que convierte los datos de un alumno en un
        /// string con un formato especifico.
        /// </summary>
        /// <returns>String con datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si el alumno toma una clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el alumno participa en la clase, false caso contrario.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Invoca la sobrecarca de Alumno == Universidad.EClase e invierte
        /// el resultado.
        /// </summary>
        /// <param name="a">Alumno.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>True si el alumno no participa en la clase, false caos contrario.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si el objeto es de tipo Alumno. Caso que sea, verifica
        /// si los alumnos contienen los mismos datos.
        /// </summary>
        /// <param name="obj">objeto a verificar.</param>
        /// <returns>True si son iguales, false caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Alumno)
            {
                return base.Equals(obj);
            }
            return false;
        }
    }
}
