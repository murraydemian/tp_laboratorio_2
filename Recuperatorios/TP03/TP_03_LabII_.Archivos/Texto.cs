using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using TP_03_LabII_.Excepciones;

namespace TP_03_LabII_.Archivos
{
    /// <summary>
    /// Permite leer y escribir sobre archivos de texto.
    /// </summary>
    public class Texto : IArchivo<string> 
    {
        /// <summary>
        /// Lee datos de un archivo de texto y los retorna como string.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="datos">Salida de datos.</param>
        /// <returns>true si la ruta es valida.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {                    
                    datos = "";
                    datos = reader.ReadToEnd();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }            
        }
        /// <summary>
        /// Toma datos de un string y los escribe sobre un archivo de texto. No concatena, reemplaza.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="dato">Entrada de datos.</param>
        /// <returns>true si la ruta es valida.</returns>
        public bool Guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(dato);
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        
    }

    
}
