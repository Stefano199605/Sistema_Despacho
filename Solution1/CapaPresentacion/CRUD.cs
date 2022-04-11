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
        private string dni = null;
        

        public CRUD()
        {
            InitializeComponent();
            MostrarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objectoCN.InsertarClient(txtDNI.Text, txtNombre.Text, txtApellido.Text,txtEmail.Text, txtTelefono.Text);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProductos();
                    limpiar();
                }catch(Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por:" + ex);
                }
            }

            if (Editar == true)
            {
                try
                {
                    objectoCN.EditarClient(txtDNI.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    limpiar();
                    Editar = false;
                }catch(Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por:" + ex);
                }
            }
        }
        private void limpiar()
        {
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }
        private void MostrarProductos()
        {
            CN_Cliente objeto = new CN_Cliente();
            dgvListado.DataSource = objeto.MostrarProducto();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                Editar = true;
                txtDNI.Text = dgvListado.CurrentRow.Cells["DNI"].Value.ToString();
                txtNombre.Text = dgvListado.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtApellido.Text = dgvListado.CurrentRow.Cells["APELLIDO"].Value.ToString();
                txtEmail.Text = dgvListado.CurrentRow.Cells["EMAIL"].Value.ToString();
                txtTelefono.Text = dgvListado.CurrentRow.Cells["TELEFONO"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                dni = dgvListado.CurrentRow.Cells["DNI"].Value.ToString();
                
                objectoCN.EliminarClient(dni);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Exportar_a_Excel(DataGridView datalistado)
        {
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indicecolumna = 0;
            foreach (DataGridViewColumn columna in dgvListado.Columns)
            {
                indicecolumna++;
                exportarExcel.Cells[1, indicecolumna] = columna.Name;
            }
            int indicefila = 0;
            foreach (DataGridViewRow fila in dgvListado.Rows)
            {
                indicefila++;
                indicecolumna = 0;
                foreach (DataGridViewColumn columna in dgvListado.Columns)
                {
                    indicecolumna++;
                    exportarExcel.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarExcel.Visible = true;
            //}


        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar_a_Excel(dgvListado);
        }
    }
}
