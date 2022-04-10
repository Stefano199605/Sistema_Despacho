using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace CapaDatos
{
   public class CD_Clientes
    {
        private Conexion con = new Conexion();
        OracleDataReader leer;
        DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        public DataTable Mostrar()
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("SP_SELECT_CLIENTE");
            comando.CommandType = CommandType.StoredProcedure;

        }
    }
}
