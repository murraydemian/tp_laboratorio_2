using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_03_LabII_.Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            :this("La nacionalidad no se condice con el numero de DNI.")
        {
            
        }
        public NacionalidadInvalidaException(string message)
            :base(message)
        {

        }
    }
}
