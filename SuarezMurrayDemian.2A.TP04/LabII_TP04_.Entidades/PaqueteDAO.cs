using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace LabII_TP04_.Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;            
        }

        public static bool Insertar(Paquete p)
        {
            string comando = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno)" +
                " VALUES ('{0}','{1}','Suarez Murray Demian')", p.DireccionEntrega, p.TrakingID);
            PaqueteDAO.comando.CommandText = comando;
            PaqueteDAO.conexion.Open();
            PaqueteDAO.comando.ExecuteNonQuery();
            PaqueteDAO.conexion.Close();
            return true;
        }
    }
}
