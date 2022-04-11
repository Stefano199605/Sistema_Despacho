using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
   public class CN_Cliente
    {
        private CD_Clientes objectoCD = new CD_Clientes();

        public DataTable MostrarProducto()
        {
            DataTable tabla = new DataTable();
            tabla = objectoCD.Mostrar();
            return tabla;
        }

        public void InsertarClient(string dni,string nombre,string apellido,string email,string telefono)
        {
            objectoCD.Insertar(Convert.ToInt32(dni), nombre, apellido, email, Convert.ToInt32(telefono));
        }
        public void EditarClient(string dni,string nombre,string apellido,string email,string telefono)
        {
            objectoCD.Editar(Convert.ToInt32(dni), nombre, apellido, email, Convert.ToInt32(telefono));
        }
        public void EliminarClient(string dni)
        {
            objectoCD.Eliminar(Convert.ToInt32(dni));
        }

    }
}
