using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TP_03_LabII_.Excepciones;


namespace TP_03_LabII_.ClasesAbstractas
{
    /// <summary>
    /// Representacion abstracta de una persona.
    /// </summary>
    abstract public class Persona
    {
        #region ENacionalidad
        /// <summary>
        /// Enumerado de nacionalidad.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
                        
        #region Propiedades
        /// <summary>
        /// Permite operar con el apellido de una persona. Set valida que el valor sea
        /// un nombre.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if(Persona.ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }
        /// <summary>
        /// Permite operar con el dni de una persona. Set valida que el valor sea un dni 
        /// y que sea acorde a la nacionalidad.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = Persona.ValidarDni(this.nacionalidad, value);
                }
                catch(DniInvalidoException e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// Permite operar con la nacionalidad de una persona. Set verifica que 
        /// la nacionalidad se coincida con el numero de documento.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                try
                {
                    Persona.ValidarDni(value, this.DNI);
                    this.nacionalidad = value;
                }
                catch(DniInvalidoException)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad que se esta intentando " +
                        "definir no coincide con el DNI de la persona.");
                }
            }
        }
        /// <summary>
        /// Permite operar con el nombre de una persona. Set verifica que el valor sea 
        /// un nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(Persona.ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }
            }
        }
        /// <summary>
        /// Permite setear el dni de una persona a partir de un string.
        /// Se verifica que sea un numero valido y se coincida con la nacionalidad.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona(){ }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;            
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        /// <summary>
        /// Retorna una persona representada por un string con formato.
        /// </summary>
        /// <returns>Datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder persona = new StringBuilder();
            persona.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n"
                , this.Apellido, this.Nombre);
            persona.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return persona.ToString();
        }
        /// <summary>
        /// Verifica que el DNI asignado coincida con la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalida de la persona.</param>
        /// <param name="dato">Numero de documento a verificar.</param>
        /// <returns>El numero de documento, si es valido.</returns>
        protected static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(dato > 0 && dato < 90000000)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }
                throw new NacionalidadInvalidaException();
            }
            else if(dato >= 90000000 && dato <= 99999999)
            {
                if(nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }
                throw new NacionalidadInvalidaException();
            }
            else
            {
                throw new DniInvalidoException("Numero de documento fuera de rango, se esperaba " +
                    "un valor entre 1 y 99.999.999. El valor entregado es " + dato.ToString());
            }
        }
        /// <summary>
        /// Verifica que el DNI asignado coincida con la nacionalida de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalida de la persona.</param>
        /// <param name="dato">Numero de documento.</param>
        /// <returns>El numero de documento, si es valido.</returns>
        protected static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                int parseBuffer = int.Parse(dato);
                return Persona.ValidarDni(nacionalidad, parseBuffer);
            }
            catch(FormatException)
            {
                throw new DniInvalidoException("La cadena contiene caracteres no correspondientes" +
                    " a un DNI.");
            }
        }
        /// <summary>
        /// Verifica que un string contanga solamente caracteres valido para un nombre
        /// o apellido (solamente letras o espacios). 
        /// </summary>
        /// <param name="dato">String a validar.</param>
        /// <returns>Si el dato es valido lo retorna, de lo contrario retorna null</returns>
        protected static string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrWhiteSpace(dato))
            {
                Regex rx = new Regex(@"[^A-Za-z\s]");
                if(!rx.IsMatch(dato))
                {
                    return dato;
                }
            }
            return null;
        }
    }
}
