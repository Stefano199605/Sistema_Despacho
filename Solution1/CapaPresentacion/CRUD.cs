using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class CRUD : Form
    {
        CN_Cliente objectoCN = new CN_Cliente();
        private bool Editar = false;
        public CRUD()
        {
            InitializeComponent();
            MostrarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                //try
                //{
                //    objectoCN.InsertarClient(txtDNI.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text,txtTelefono.Text);
                //    MessageBox.Show("Se inserto correctamente");
                //    MostrarProductos();

                //}
            }
        }
        private void MostrarProductos()
        {
            CN_Cliente objeto = new CN_Cliente();
            dgvListado.DataSource = objeto.MostrarProducto();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            
        }
    }
}
