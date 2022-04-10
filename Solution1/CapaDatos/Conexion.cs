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
   public class Conexion
    {
        private OracleConnection con = new OracleConnection("Data source=orcl;Password=123;USER ID=proy");
        public OracleConnection AbrirConexion()
        {
            if(con.State== ConnectionState.Closed)
            {
                con.Open();
                
            }
            return con;
            
        }
        public OracleConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
    }
}
