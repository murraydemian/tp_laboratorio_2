using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_03_LabII_.Excepciones;
using TP_03_LabII_.Archivos;
using System.Windows.Forms;

namespace TP_03_LabII_.ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            try
            {
                this.Instructor = instructor;
            }
            catch(SinProfesorException x)
            {
                throw x;
            }
        }
        /// <summary>
        /// Permite operar con la lista de alumnos pertenecientes a una jornada.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                try
                {
                    this.alumnos = value;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// Permite operar con la Universidad.EClase perteneciente a una jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                if (this.instructor == value)
                {
                    this.clase = value;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
        }
        /// <summary>
        /// Permite operar con el profesor perteneciente a una jornada. Se verifica
        /// que el profesor sea capas de impartir la clase de la jornada.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                if (value == this.clase)
                {
                    this.instructor = value;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
        }
        /// <summary>
        /// Guarda los datos de una jornada en un archivo de texto en /MisDocumentos/SuarezMurray2A.
        /// Si la carpeta no existe, la crea.
        /// </summary>
        /// <param name="jornada">La jornada a guardar.</param>
        /// <returns>True si la Jornada es valida.</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) 
                    + @"\SuarezMurray2A";
                System.IO.Directory.CreateDirectory(path);
                Texto archivoTexto = new Texto();
                archivoTexto.Guardar((path + @"\Jornada.txt"), jornada.ToString());
                return true;
            }
            catch(Exception e)
            {
                e.Source = "Metodo Guardar perteneciente a Jornada";
                throw e;
            }
        }
        /// <summary>
        /// Lee el archivo de texto donde se guarda la jornada (ver: jornada.Guardar()),
        /// y retorna los datos como string.
        /// </summary>
        /// <returns>Datos de la jornada guardada.</returns>
        public static string Leer()
        {
            try
            {
                string jornada = "";
                Texto archivoTexto = new Texto();
                archivoTexto.Leer((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) +
                        @"\SuarezMurray2A\Jornada.txt", out jornada);
                return jornada;
            }
            catch(Exception e)
            {
                e.Source = "Metodo Leer preteneciente a Jornada";
                throw e;
            }
        }
        /// <summary>
        /// Verifica si un alumno participa en la clase de la jornada.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>True si el alumno participa, false caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }
        /// <summary>
        /// Verifica si el alumno no participa en la clase de la jornada.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>True si el alumno no participa, false caso contrario.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Verifica si el alumno participa en la clase de la jornada, si 
        /// el alumno participa y aun no esta en la jornada, lo agrega.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>La jornada con o sin alumno.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                foreach(Alumno itemAlumno in j.Alumnos) //recorro la jornada
                {
                    if (itemAlumno.Equals(a)) //reviso que el alumno no sea repetido
                    {
                        return j; //si el alumno ya esta, rompo el bucle
                    }
                }
                j.Alumnos.Add(a); //si llego al final y no encontre al alumno, lo agrego
            }
            return j;
        }
        /// <summary>
        /// Convierte los datos de una jornada a string.
        /// </summary>
        /// <returns>String con datos de jornada.</returns>
        public override string ToString()
        {
            StringBuilder jornada = new StringBuilder();
            jornada.AppendFormat("CLASE DE {0} POR {1}",
                this.clase.ToString(), this.instructor.ToString());
            jornada.AppendLine("ALUMNOS:");
            foreach(Alumno itemAlumno in this.alumnos)
            {
                jornada.AppendLine(itemAlumno.ToString());
            }
            //jornada.AppendLine("<------------------------------------------------->");
            return jornada.ToString();
        }
    }
}
