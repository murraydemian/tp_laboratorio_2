using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                try
                {
                    this.apellido = Persona.ValidarNombreApellido(value);
                }
                catch(Exception e)
                {
                    throw e;
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
                    this.dni = Persona.ValidarDni(this.Nacionalidad, value);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// Permite operar con la nacionalidad de una persona. Set verifica que sea que 
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
                catch(Exception e)
                {
                    throw e;
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
                try
                {
                    this.nombre = Persona.ValidarNombreApellido(value);                    
                }
                catch(Exception e)
                {
                    throw e;
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
                try
                {
                    this.dni = Persona.ValidarDni(this.Nacionalidad, value);                    
                }
                catch(DniInvalidoException e)
                {
                    throw e;
                }
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
            try
            {
                this.StringToDNI = dni;
            }
            catch(Exception e)
            {
                throw new NacionalidadInvalidaException();
            }
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
            try
            {
                switch (nacionalidad)
                {
                    case (ENacionalidad.Argentino):
                        if(dato > 0 && dato < 90000000)
                        {
                            return dato;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("Es argentino pero el DNI es " + dato.ToString());
                        }                    
                    case (ENacionalidad.Extranjero):
                        if (dato >= 90000000 && dato <= 99999999)
                        {
                            return dato;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("Es extranjero pero el DNI es " + dato.ToString());
                        }
                    default:
                        throw new NacionalidadInvalidaException("Nacionalidad no valida.");
                }
            }
            catch(Exception e)
            {
                throw new DniInvalidoException(e);
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
            catch(Exception e)
            {
                throw new DniInvalidoException(e);
            }
        }
        /// <summary>
        /// Verifica que un string contanga solamente caracteres valido para un nombre
        /// o apellido (solamente letras o espacios). 
        /// </summary>
        /// <param name="dato">String a validar.</param>
        /// <returns>String dato, si es valido.</returns>
        protected static string ValidarNombreApellido(string dato)
        {
            try
            {
                if(!(string.IsNullOrWhiteSpace(dato)))
                {
                    foreach(char character in dato)
                    {
                        if(char.IsLetter(character) || char.IsWhiteSpace(character))
                        {
                            continue;
                        }
                        else
                        {
                            throw new FormatException("El dato contiene caracteres invalidos.");
                        }
                    }
                    return dato;
                }
                else
                {
                    throw new FormatException("Dato null o en blanco.");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
