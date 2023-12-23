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
    public enum Modo
    {
        CREAR,
        EDITAR
    }
    public partial class ProductoDetails : Form
    {
        private Modo modo = Modo.CREAR;
        private int id = 0;
        private bool isModified = false;

        public ProductoDetails(Modo modo, int id = 0)
        {
            InitializeComponent();
            this.modo = modo;
            this.id = id;
        }

        private void loadProducto()
        {
            ProductoDB productoDB = new ProductoDB();
            Producto producto = productoDB.GetProducto(this.id);
            txtIdProducto.Text = producto.IDProducto.ToString();
            txtNombre.Text = producto.Nombre.ToString();
            txtCosto.Text = producto.Costo.ToString();
            cmbEstado.SelectedIndex = producto.Estado == 1 ? 0 : 1;
            txtPrecio.Text = producto.Precio.ToString();
        }

        // Boton aplicar.
        private void button2_Click(object sender, EventArgs e)
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

            this.UpdateStateForms(false);
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
                this.loadProducto();
                this.updateTitle();
            }
            this.UpdateStateForms(false);
        }

        private void updateTitle()
        {
            this.Text = $"Producto <{txtNombre.Text.Trim()}>";
        }

        private void UpdateStateForms(bool isModified)
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
            ProductoDB productoDB = new ProductoDB();

            Producto producto = new Producto();
            producto.Nombre = txtNombre.Text.Trim();
            producto.Costo = Convert.ToDecimal(txtCosto.Text.Trim());
            producto.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
            producto.Estado = cmbEstado.Text.Trim() == "Activo" ? 1 : 0;
            
            producto.IDProducto = productoDB.agregarProducto(producto);

            // actualizamos el id del cliente en el formulario
            txtIdProducto.Text = producto.IDProducto.ToString();
            this.updateTitle();
            this.modo = Modo.EDITAR;
        }

        private void EditarProducto()
        {
            ProductoDB productoDB = new ProductoDB();

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
                this.updateTitle();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el producto");
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtNombre.Text))
            {
                txtNombre.Tag = helpers.FormsValidatros.IsTextLength(txtNombre, lblNombre, 50, 4);
            }
            else
            {
                lblNombre.ForeColor = System.Drawing.Color.Black;
            }

            this.UpdateStateForms(true);
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtCosto.Text))
            {
                txtCosto.Tag = helpers.FormsValidatros.IsTextPrecio(txtCosto, lblCosto);
            }
            else
            {
                lblCosto.ForeColor = System.Drawing.Color.Black;
            }

            this.UpdateStateForms(true);
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtPrecio.Text))
            {
                txtPrecio.Tag = helpers.FormsValidatros.IsTextPrecio(txtPrecio, lblPrecio);
            }
            else
            {
                lblPrecio.ForeColor = System.Drawing.Color.Black;
            }

            this.UpdateStateForms(true);
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateStateForms(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
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
            ProductoDB productoDB = new ProductoDB();
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
