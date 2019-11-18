using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_03_LabII_.ClasesAbstractas;

namespace TP_03_LabII_.ClasesInstanciables
{
    public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            Profesor.random = new Random();
        }
        public Profesor()
            : base ()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// Agrega dos clases a un profesor, las clases pueden o no ser iguales.
        /// </summary>
        private void _randomClases()
        {
            while (this.clasesDelDia.Count < 2) 
            {
                switch(Profesor.random.Next(1, 4))
                {
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);                        
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 4:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            } 
        }
        /// <summary>
        /// Convierte los datos de un profesor en string.
        /// </summary>
        /// <returns>String con datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder profesor = new StringBuilder();
            profesor.AppendFormat("{0}", base.MostrarDatos());
            profesor.AppendLine(this.ParticiparEnClase());
            return profesor.ToString();
        }
        /// <summary>
        /// Convierte las clases en las que participa el profesor a string.
        /// </summary>
        /// <returns>Clases en las que participa el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder();
            clases.AppendLine("CLASES DEL DIA: ");
            foreach(Universidad.EClases itemClase in this.clasesDelDia)
            {
                clases.AppendLine(itemClase.ToString());
            }
            return clases.ToString();
        }
        /// <summary>
        /// Convierte los datos de un profesor a string.
        /// </summary>
        /// <returns>Datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Verifica si el profesor participa en la clase indicada.
        /// </summary>
        /// <param name="i">Profesor.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>True si el profesor participa, false caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si el profesor no participa en la clase indicada.
        /// </summary>
        /// <param name="i">Profesor.</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor no participa en la clase, false caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Verifica si un objeto es de tipo Profesor, caso que lo sea verifica si
        /// es igual al profesor que se usa para llamar al metodo.
        /// </summary>
        /// <param name="obj">Objeto a verificar.</param>
        /// <returns>True si son iguales, false caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if(obj is Profesor)
            {
                return base.Equals(obj);
            }
            return false;
        }
    }
}
