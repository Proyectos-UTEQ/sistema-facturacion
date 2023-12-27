using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturacion.models;

namespace Facturacion.productos
{
    public partial class ProductoListaForm : Form
    {
        public ProductoListaForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void ListadoProductos_Load(object sender, EventArgs e)
        {
            this.RefreshList();
        }
        private async void RefreshList()
        {
            ProductoRespositorio productoDB = new ProductoRespositorio();
            lblStatus.Text = "Cargando productos...";

            toolStripProgressProductos.Visible = true;
            toolStripProgressProductos.Style = ProgressBarStyle.Marquee;

            await Task.Delay(500);
            dgvProductos.DataSource = productoDB.ObtenerListaProductos(txtSearch.Text);
            dgvProductos.Columns["IDProducto"].Visible = false;
            dgvProductos.Columns["Estado"].Visible = false;

            toolStripProgressProductos.Style = ProgressBarStyle.Continuous;
            toolStripProgressProductos.Visible = false;
            lblStatus.Text = "Productos cargados";
        }

        private void toolStripButtonNuevoProducto_Click(object sender, EventArgs e)
        {
            ProductoDetallesForm productoDetails = new ProductoDetallesForm(Modo.CREAR);
            productoDetails.ShowDialog();
            this.RefreshList();
        }

        private void dgvProductos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //aquí
        }

        private void Fila_DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.ObtenerIDProductoSeleccionado();
            ProductoDetallesForm productoDetails = new ProductoDetallesForm(Modo.EDITAR, id);
            productoDetails.ShowDialog();
            this.RefreshList();
        }

        private int ObtenerIDProductoSeleccionado()
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["IDProducto"].Value);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var id = this.ObtenerIDProductoSeleccionado();
            if (id == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            ProductoRespositorio productoDB = new ProductoRespositorio();
            var row = productoDB.EliminarProducto(id);
            if (row > 0)
            {
                MessageBox.Show("Producto eliminado correctamente");
                this.RefreshList();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.RefreshList();
        }
    }
}
