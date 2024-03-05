using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;

namespace Modelo
{
    public class ConexionModelo
    {
        private static string cadenaConexion = "Server=LAPTOP-SANTI;Database=biosys;Integrated Security=true";

        public static SqlConnection AbrirConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public static void CerrarConexion(SqlConnection conexion)
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }

}
