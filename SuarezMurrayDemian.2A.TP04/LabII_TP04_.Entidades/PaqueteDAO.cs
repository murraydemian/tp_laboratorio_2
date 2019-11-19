using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LabII_TP04_.Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {

        }

        public static bool Insertar()
        {
            return true;
        }
    }
}
