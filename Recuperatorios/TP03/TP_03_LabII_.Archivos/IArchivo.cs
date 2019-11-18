using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_03_LabII_.Archivos
{
    public interface IArchivo <T> 
    {
        /// <summary>
        /// Este metodo debera implementarse con la finalidad de guardar datos.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Este metodo debera implementarse con la finalidad de leer los datos guardados
        /// por el metodo Guardar.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);        
    }
}
