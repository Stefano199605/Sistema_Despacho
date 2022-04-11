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
            comando = new OracleCommand("seleccionarCliente", comando.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction=ParameterDirection.Output;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
            
            
            
            
            
        }
        public void Insertar(int dni, string nombre,string apellido,string email, int telefono)
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("SP_insertarCliente",comando.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("p_dni", OracleDbType.Varchar2).Value = dni;
            comando.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = nombre;
            comando.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = apellido;
            comando.Parameters.Add("p_email", OracleDbType.Varchar2).Value = email;
            comando.Parameters.Add("p_telefono", OracleDbType.Int64).Value = telefono;
            comando.Parameters.Add("p_result", OracleDbType.Varchar2).Value = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
            
        }
        public void Eliminar(int dni)
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("sp_eliminarCliente", comando.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("p_dni", OracleDbType.Varchar2).Value = dni;
            comando.Parameters.Add("p_result", OracleDbType.Varchar2).Value = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            con.CerrarConexion();
        }
        public void Editar(int dni, string nombre, string apellido,string email, int telefono)
        {
            comando.Connection = con.AbrirConexion();
            comando = new OracleCommand("sp_updateCliente",comando.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("p_dni", OracleDbType.Varchar2).Value = dni;
            comando.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = nombre;
            comando.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = apellido;
            comando.Parameters.Add("p_email", OracleDbType.Varchar2).Value = email;
            comando.Parameters.Add("p_telefono", OracleDbType.Int64).Value = telefono;
            comando.Parameters.Add("p_result", OracleDbType.Varchar2).Value = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            con.CerrarConexion();

        }


    }
}
