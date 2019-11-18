using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TP_03_LabII_.Excepciones;

namespace TP_03_LabII_.Archivos
{
    /// <summary>
    /// Permite leer y escribir sobre archivos .xml.
    /// </summary>
    /// <typeparam name="T">Debe ser una clase</typeparam>
    public class Xml<T> : IArchivo<T> where T : class
    {
        /// <summary>
        /// Toma datos de tipo T y los guarda en un archivo .xml en la ruta indicada.
        /// No concatena, reemplaza.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="datos">Objeto a guardar.</param>
        /// <returns>true si la ruta es valida.</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StreamWriter writer = new StreamWriter(archivo);
                xmlSerializer.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }            
        }
        /// <summary>
        /// Lee datos tipo T de un archivo .xml y los guarda en un objeto tipo T. 
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="datos">Salida de datos.</param>
        /// <returns>true si la ruta es valida.</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);
                datos =(T)xmlSerializer.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }            
        }
    }
}
