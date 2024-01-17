using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturacion.Helpers;
using Facturacion.models;

namespace Facturacion.productos
{
    public partial class ProductoListaForm : Form
    {
        private Modo modo;

        public event EventHandler<int> OnProductoSeleccionado;

        public ProductoListaForm(Modo modo = Modo.NORMAL)
        {
            InitializeComponent();
            this.modo = modo;
        }

        private void EnviarProductoSeleccionado(int id)
        {
            if (OnProductoSeleccionado != null)
            {
                OnProductoSeleccionado?.Invoke(this, id);
            }
        }

        private void ListadoProductos_Load(object sender, EventArgs e)
        {
            // this.RefreshList();
            if (modo == Modo.SELECIONAR)
            {
                BtnSeleccionar.Visible = true;
                toolStripButtonNuevoProducto.Visible = false;
                toolStripButton2.Visible = false;
            }
            else
            { 
                BtnSeleccionar.Visible = false;
            }

            // selecionamos el nombre para buscar por defecto.
            CampoSelecionado.SelectedIndex = 1;
        }
        private void CargarLista()
        {

            // En caso de estar basico el campo para buscar.
            if (txtSearch.Text.Length == 0)
            {
                return;
            }

            ProductoRespositorio productoDB = new ProductoRespositorio();
            lblStatus.Text = "Cargando productos...";

            toolStripProgressProductos.Visible = true;
            toolStripProgressProductos.Style = ProgressBarStyle.Marquee;

            dgvProductos.DataSource = productoDB.ObtenerListaProductos(txtSearch.Text, CampoSelecionado.Text);

            toolStripProgressProductos.Style = ProgressBarStyle.Continuous;
            toolStripProgressProductos.Visible = false;
            lblStatus.Text = "Productos cargados";
        }

        private void toolStripButtonNuevoProducto_Click(object sender, EventArgs e)
        {
            ProductoDetallesForm productoDetails = new ProductoDetallesForm(Modo.CREAR);
            productoDetails.ShowDialog();
            this.CargarLista();
        }

        private void Fila_DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.ObtenerIDProductoSeleccionado();
            ProductoDetallesForm productoDetails = new ProductoDetallesForm(Modo.EDITAR, id);
            productoDetails.ShowDialog();
            this.CargarLista();
        }

        private int ObtenerIDProductoSeleccionado()
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["ID_PRODUCTO"].Value);
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
                this.CargarLista();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.CargarLista();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.CargarLista();
        }

        // botón de seleccionar para enviar el producto al otro formulario.
        private void BtnSeleccionar_Click_1(object sender, EventArgs e)
        {
            var id = ObtenerIDProductoSeleccionado();
            if (id == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }
            else
            { 
                // enviamos y cerramos el formulario.
                EnviarProductoSeleccionado(id);
                Close();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CargarLista();
                e.Handled = true;
            }
        }
    }
}
