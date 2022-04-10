using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
namespace CapaPresentacion
{
    public partial class Login : Form
    {
        Conexion CON = new Conexion();

        public Login()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            CON.AbrirConexion();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            CON.CerrarConexion();
        }
    }
}
