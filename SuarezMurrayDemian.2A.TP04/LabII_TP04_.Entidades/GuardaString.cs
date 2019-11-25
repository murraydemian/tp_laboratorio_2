using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabII_TP04_.Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop) + @"\" + archivo + ".txt", true);
            using (streamWriter)
            {
                streamWriter.Write(string.Format("[{0}]\n{1}\n", DateTime.Now.ToString(), texto));
                return true;
            }
        }
    }
}
