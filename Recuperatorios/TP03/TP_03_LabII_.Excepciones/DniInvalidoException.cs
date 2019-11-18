using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_03_LabII_.Excepciones
{
    public class DniInvalidoException : Exception
    { 
        private string mensajeBase; 

        public DniInvalidoException()
            : this("Caracteres invalidos o fuera de rango.")
        {
            
        }
        public DniInvalidoException(Exception e)
            : this("Caracteres invalidos o fuera de rango.", e)
        {

        }
        public DniInvalidoException(string message)
            : base(message)
        {
            
        }
        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }

    }
}
