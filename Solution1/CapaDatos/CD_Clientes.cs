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
        private Datos dt = new Datos();

        public DataTable Mostrar()
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("SP_SELECT_CLIENTE");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("P_CURSOR",OracleDbType.RefCursor).Direction=ParameterDirection.Output;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }
        public void Insertar(char dni, string nombre,string apellido,string email, int telefono)
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("SP_INSERT_CLIENTE");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("P_DNI", OracleDbType.Char).Value = dni;
            comando.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
            comando.Parameters.Add("P_APELLIDO", OracleDbType.Varchar2).Value = apellido;
            comando.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = email;
            comando.Parameters.Add("P_TELEFONO", OracleDbType.Int64).Value = telefono;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
            
        }
        public void Eliminar(char dni)
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("SP_DELETE_CLIENTE");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("P_DNI", OracleDbType.Char).Value = dni;
            comando.ExecuteNonQuery();
            con.CerrarConexion();
        }
        public void Editar(char dni, string nombre, string apellido,string email, int telefono)
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("SP_INSERT_CLIENTE");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("P_DNI", OracleDbType.Char).Value = dni;
            comando.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
            comando.Parameters.Add("P_APELLIDO", OracleDbType.Varchar2).Value = apellido;
            comando.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = email;
            comando.Parameters.Add("P_TELEFONO", OracleDbType.Int64).Value = telefono;
            comando.ExecuteNonQuery();
            con.CerrarConexion();

        }


    }
}
