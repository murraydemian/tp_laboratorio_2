using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_03_LabII_.Excepciones;
using TP_03_LabII_.Archivos;

namespace TP_03_LabII_.ClasesInstanciables
{
    public class Universidad
    {
        #region EClases
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        /// <summary>
        /// Permite oerar con la lista de alumnos perteneciente a una Universidad.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Permite operar con la lista de profesores pretenecientes a una Universidad.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Permite operar con la lista de jornadas perteneciente a una Universidad.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Permite acceder la lista de jornadas perteneciente a universidad a partir de un indice.
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>Retorna la Jornada en indice i. Si el indice es invalido retorna null</returns>
        public Jornada this[int i]
        {
            get
            {
                if(i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada.ElementAt(i);
                }
                else
                {
                    return null;
                }
            }
            set
            {                
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;                             
                }                
            }
        }
        /// <summary>
        /// Guarda los datos de una universidad en un archivo .xlm ubicado en
        /// /MisDocumentos/SuarezMurray2A. Si el directorio no existe, lo crea.
        /// </summary>
        /// <param name="uni">Universidad a guardar.</param>
        /// <returns>True si la universidad es valida.</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory()
                    + @"\ArchivosGuardados";
                System.IO.Directory.CreateDirectory(path);
                Xml<Universidad> archivo = new Xml<Universidad>();
                return archivo.Guardar((path + @"\Universidad.xml"), uni);
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }            
        }
        /// <summary>
        /// Lee los datos de la universidad guarda en un archivo .xml (ver universidad.guardar)
        /// y los ratorna en un objeto tipo Universidad.
        /// </summary>
        /// <returns>Universidad leida.</returns>
        public static Universidad Leer()
        {
            try
            {
                Universidad uni = new Universidad();
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Leer((System.IO.Directory.GetCurrentDirectory()
                    + @"\ArchivosGuardados\Universidad.xml"), out uni);
                return uni;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Convierte los datos de na universidad en un string con un formato especifico.
        /// </summary>
        /// <returns>String con datos de universidad.</returns>
        private string MostrarDatos()
        {
            StringBuilder universidad = new StringBuilder();
            universidad.AppendLine("JORNADA: ");
            foreach(Jornada itemJornada in this.Jornadas)
            {
                universidad.AppendFormat("{0}", itemJornada.ToString());
                universidad.AppendLine("<------------------------------------------------->");
            }
            return universidad.ToString();
        }
        /// <summary>
        /// Verifica si un alumno esta incluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="a">Alumno.</param>
        /// <returns>True si el alumno esta incluido, false caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno itemAlumno in g.Alumnos)
            {
                if (itemAlumno.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si un alumno no esta inluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="a">alumno.</param>
        /// <returns>True si el alumno no esta incluido, false caso contrario.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Verifica si un profesor esta incluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="i">Profesor.</param>
        /// <returns>True si el profesro esta incluido, false caso contrario.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach(Profesor itemProfesor in g.Instructores)
            {
                if (itemProfesor.Equals(i))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si un profesor no esta incluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="i">Profesor.</param>
        /// <returns>True si el profesor no esta incluido, false caso contrario.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Retorna el primer profesor que encuentre sea capas de dar la clase indicada.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor capas de dar la clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor itemProfesor in u.Instructores)
            {
                if(itemProfesor == clase)
                {
                    return itemProfesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Retorna el primer profesor que encuentre no sea capas de dar la clase indicada.
        /// </summary>
        /// <param name="i">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que no pueda dar la clase.</returns>
        public static Profesor operator !=(Universidad i, EClases clase)
        {
            foreach(Profesor itemProfesor in i.Instructores)
            {
                if (itemProfesor != clase)
                {
                    return itemProfesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Crea una nueva Jornada de la clase indicada, agrega un profesor que pueda impartir
        /// la clase, y los alumnos que puedan tomarla. Si no se encuentra un profesor que pueda
        /// impartir la clase, se retorna la universidad sin cambio alguno.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Una jornada con su respectivos profesor y alumnos.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada nuevaJornada = new Jornada(clase, (g == clase));
                for(int i = 0; i < g.Alumnos.Count; i++)
                {
                    if(g.Alumnos[i] == clase)
                    {
                        nuevaJornada.Alumnos.Add(g.Alumnos[i]);
                    }
                }
                g.Jornadas.Add(nuevaJornada);
                return g;
            }
            catch(SinProfesorException)
            {
                return g;
            }            
        }
        /// <summary>
        /// Verifica que no este repetido, y agrega un alumno a la unniversidad.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con o sin alumno agregado, dependiendo lo que corresponda.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);                     
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Verifica qeue no este repetido y agrega un profesor a una universidad.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad con o sin profesor agregado.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }
        /// <summary>
        /// Convierte los datos de una Universidad a string.
        /// </summary>
        /// <returns>String con datos de la universidad.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
