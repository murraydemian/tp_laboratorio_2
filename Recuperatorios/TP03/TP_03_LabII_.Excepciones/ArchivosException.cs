using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_03_LabII_.Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException)
            :base("Excepcion de archivo.", innerException)
        {

        }
    }
}
