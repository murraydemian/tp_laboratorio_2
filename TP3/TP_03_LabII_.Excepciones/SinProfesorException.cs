using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_03_LabII_.Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
            :base("No hay Profesor para la clase")
        {

        }
    }
}
