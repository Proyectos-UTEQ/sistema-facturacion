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
using Facturacion.Models;

namespace Facturacion.productos
{
    
    public partial class ProductoDetallesForm : Form
    {
        private Modo modo = Modo.CREAR;
        private int id = 0;
        private bool isModified = false;

        public ProductoDetallesForm(Modo modo, int id = 0)
        {
            InitializeComponent();
            this.modo = modo;
            this.id = id;
        }

        private void LoadProducto()
        {
            ProductoRespositorio productoDB = new ProductoRespositorio();
            Producto producto = productoDB.GetProducto(this.id);
            txtIdProducto.Text = producto.IDProducto.ToString();
            txtNombre.Text = producto.Nombre.ToString();
            txtCosto.Text = producto.Costo.ToString();
            cmbEstado.SelectedIndex = producto.Estado == 1 ? 0 : 1;
            txtPrecio.Text = producto.Precio.ToString();
        }

        // Boton aplicar.
        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            if (!this.ValidateForm())
            {
                MessageBox.Show("Formulario invalido");
                return;
            }
            if (this.modo == Modo.CREAR)
            {
                this.CrearProducto();
            }
            else
            {
                this.EditarProducto();
            }

            this.ActualizarEstadoDelFormulario(false);
            this.Close();
        }

        private void ProductoDetails_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            if (this.modo == Modo.CREAR)
            {
                this.Text = "Crear Producto";
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.LoadProducto();
                this.ActualizarTitulo();
            }
            this.ActualizarEstadoDelFormulario(false);
        }

        private void ActualizarTitulo()
        {
            this.Text = $"Producto <{txtNombre.Text.Trim()}>";
        }

        private void ActualizarEstadoDelFormulario(bool isModified)
        {
            // controlar el estado de los botones
            if (this.modo == Modo.CREAR)
            {
                this.btnRemover.Enabled = false;
            }
            else
            {
                this.btnRemover.Enabled = true;
            }

            // controlar el estado del boton aplicar
            if (this.ValidateForm())
            {
                this.btnAplicar.Enabled = true;
            }
            else
            {
                this.btnAplicar.Enabled = false;
            }
            this.isModified = isModified;
            this.lblStatusEdit.Text = this.isModified ? "Modificado" : "Sin Modificar";
        }

        private bool ValidateForm()
        {
            bool nombre = txtNombre.Tag != null ? (bool)txtNombre.Tag : false;
            bool costo = txtCosto.Tag != null ? (bool)txtCosto.Tag : false;
            bool precio = txtPrecio.Tag != null ? (bool)txtPrecio.Tag : false;
            //bool estado = cmbEstado.Tag != null ? (bool)cmbEstado.Tag : false;
            bool estado = cmbEstado.SelectedItem != null;

            return nombre && costo && precio && estado;
        }

        private void CrearProducto()
        {
            ProductoRespositorio productoDB = new ProductoRespositorio();

            Producto producto = new Producto();
            producto.Nombre = txtNombre.Text.Trim();
            producto.Costo = Convert.ToDecimal(txtCosto.Text.Trim());
            producto.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
            producto.Estado = cmbEstado.Text.Trim() == "Activo" ? 1 : 0;
            
            producto.IDProducto = productoDB.agregarProducto(producto);

            // actualizamos el id del cliente en el formulario
            txtIdProducto.Text = producto.IDProducto.ToString();
            this.ActualizarTitulo();
            this.modo = Modo.EDITAR;
        }

        private void EditarProducto()
        {
            ProductoRespositorio productoDB = new ProductoRespositorio();

            Producto producto = new Producto();
            producto.IDProducto = Convert.ToInt32(txtIdProducto.Text);
            producto.Nombre = txtNombre.Text.Trim();
            producto.Costo = Decimal.Parse(txtCosto.Text.Trim());
            producto.Precio = Decimal.Parse(txtPrecio.Text.Trim());
            producto.Estado = cmbEstado.Text.Trim() == "Activo" ? 1 : 0;
            var rowAffect = productoDB.ActualizarProducto(producto);
            if (rowAffect > 0)
            {
                MessageBox.Show("Producto actualizado correctamente");
                this.ActualizarTitulo();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el producto");
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtNombre.Text))
            {
                txtNombre.Tag = helpers.FormsValidatros.IsTextLength(txtNombre, lblNombre, 50, 4);
            }
            else
            {
                lblNombre.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoDelFormulario(true);
        }

        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtCosto.Text))
            {
                txtCosto.Tag = helpers.FormsValidatros.IsTextPrecio(txtCosto, lblCosto);
            }
            else
            {
                lblCosto.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoDelFormulario(true);
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtPrecio.Text))
            {
                txtPrecio.Tag = helpers.FormsValidatros.IsTextPrecio(txtPrecio, lblPrecio);
            }
            else
            {
                lblPrecio.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoDelFormulario(true);
        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActualizarEstadoDelFormulario(true);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            // si el producto no ha sido creado, no se puede eliminar
            if (this.modo == Modo.CREAR)
            {
                MessageBox.Show("No se puede eliminar un producto que no ha sido creado");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // eliminar producto
            ProductoRespositorio productoDB = new ProductoRespositorio();
            var rowAffect = productoDB.EliminarProducto(this.id);
            if (rowAffect > 0)
            {
                MessageBox.Show("Producto eliminado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el producto");
            }
        }
    }
}
