using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static  SqlConnection conexion;
        private static SqlCommand comando;
        
        static PaqueteDAO()
        {
            string stringConnection = "Data Source=[Instancia Del Servidor];Initial Catalog =[Nombre de la Base de Datos]; Integrated Security = True";
            conexion = new SqlConnection(stringConnection);
        }
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string comandoString = "INSERT INTO Paquetes (direccionEntrega, trakingID, alumno)  VALUES('" + p.DireccionEntrega + "', '" + p.TrakingId + "', 'HectorSangla');";
            comando = new SqlCommand(comandoString, conexion);
            try
            {
                conexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = comandoString;
                comando.ExecuteNonQuery();
                retorno = true;
            }catch(Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return retorno;
        }
    }
}
