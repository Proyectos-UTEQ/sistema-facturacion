using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturacion.data;
using Facturacion.facturas;
using Facturacion.Helpers;
using Facturacion.models;
using Facturacion.Models;
using Facturacion.productos;

namespace Facturacion.detallefacturas
{

    // Este formulario estara enfocado en agregar o modificar productos que se 
    // agregen al detalle de la la factura.

    public partial class FacturaDetallesForm : Form
    {
        List<FacturaDetalles> detalleFacturas = new List<FacturaDetalles>();
        FacturaDetalles detalle = new FacturaDetalles();
        Factura factura = new Factura();

        public event EventHandler<FacturaDetalles> OnFacturaDetallesChanged;

        private Modo modo = Modo.CREAR; 
        private int IDFactura = 0;
        private int idFactura = 0;
        private int idProducto = 0;
        private bool isModified = false;

        public FacturaDetallesForm(Modo modo, int id = 0)
        {
            InitializeComponent();
            this.IDFactura = id;
            this.modo = modo;
        }

        public FacturaDetallesForm(Factura factura, Modo modo, int id=0)
        {
            InitializeComponent();
            this.IDFactura = id;
            this.modo = modo;
            this.factura = factura; 
        }
        public FacturaDetallesForm(Modo modo, IDS ids, int id)
        {
            InitializeComponent();
            this.IDFactura= id;
            this.idFactura = ids.IDFactura;
            this.idProducto = ids.IDProducto;
            this.modo = modo; 
        }

        // Enviar Factura detalles al formulario padre.
        private void EmitirFacturaDetalle(FacturaDetalles detalles)
        {
            if (OnFacturaDetallesChanged != null)
            { 
                OnFacturaDetallesChanged?.Invoke(this, detalles);
            }
        }


        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            if (this.modo == Modo.CREAR)
            {
                // establecemos el titulo y el id de la factura
                this.Text = "Agregar producto a factura"; 
                txtIDFact.Text = IDFactura.ToString();
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.loadFactura();
                this.updateTitle();
            }
            this.UpdateStateForms(false);
        }

         
        private void loadFactura()
        {
            FacturaDetallesRepositorio facturasDetalleDB = new FacturaDetallesRepositorio();
            FacturaDetalles facturasDetalle = facturasDetalleDB.GetFacturaDetalle(this.idFactura,this.idProducto);  

            txtIDDETFAC.Text = facturasDetalle.IDFacturaDetalle.ToString();
            txtIDFact.Text = facturasDetalle.IDFactura.ToString();
            txtIDProd.Text = facturasDetalle.IDProducto.ToString();
            TxtCantidad.Text = facturasDetalle.Cantidad.ToString("N2"); 
            TxtPrecUnit.Text = facturasDetalle.PrecioUnitario.ToString("N2"); 
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            // validar 

            if (!ValidateForm()) 
            {
                MessageBox.Show("Formulario incompleto.");
                return;
            }

            FacturaDetalles detalle = new FacturaDetalles
            {
                IDFactura = Convert.ToInt32(txtIDFact.Text),
                IDProducto = Convert.ToInt32(txtIDProd.Text),
                Descripcion = TxtDescripcion.Text,
                Cantidad = Convert.ToDecimal(TxtCantidad.Text),
                SubTotal = GetSubTotal(),
                PrecioUnitario = Convert.ToDecimal(TxtPrecUnit.Text)
            };

            // TODO: Enviar al formulario de factura.
            EmitirFacturaDetalle(detalle);
            LimpiarFormulario();

            //if (!this.ValidateForm())
            //{
            //    MessageBox.Show("Formulario invalido");
            //    return;
            //}

            //if (this.modo == Modo.CREAR)
            //{
            //    this.CrearFactura();
            //}
            //else
            //{
            //    this.EditarFactura();
            //}

            //this.UpdateStateForms(false);
            //MessageBox.Show("SE A REALIZADO LA VENTA EXITOSAMENTE");
            //this.Close();
        }

        public void LimpiarFormulario() { 
            txtIDProd.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtCantidad.Text = "0";
            TxtPrecUnit.Text = "0";
        }

        private void CrearFactura()
        {
            FacturaDetallesRepositorio detalleFacturaDB = new FacturaDetallesRepositorio(); 
            FacturaRepositorio facturaDB = new FacturaRepositorio();

            // enviamos los datos a detalle factura
            // esperamos a la db  
            facturaDB.RegistrarNuevaFactura(this.factura);
            int id= facturaDB.GetIDFinal();
            detalleFacturaDB.AddFacturaDetalle(detalleFacturas, id);

            this.updateTitle();
            this.modo = Modo.EDITAR;
        }

        private void CrearProducto()
        {
            FacturaDetallesRepositorio detalleFacturaDB = new FacturaDetallesRepositorio();
       
            // enviamos los datos a detalle factura
            // esperamos a la db    
            detalleFacturaDB.AddFacturaDetalle(detalleFacturas, this.IDFactura);

            this.updateTitle();
            this.modo = Modo.EDITAR;
        }

        private void EditarFactura()
        {
            FacturaDetallesRepositorio detalleFacturaDB = new FacturaDetallesRepositorio();

            FacturaDetalles detalleFactura = new FacturaDetalles();
            detalleFactura.IDFactura = Convert.ToInt32(txtIDFact.Text.Trim());
            detalleFactura.IDProducto = Convert.ToInt32(txtIDProd.Text.Trim());
            detalleFactura.Cantidad = Convert.ToDecimal(TxtCantidad.Text.Trim()); 
            detalleFactura.PrecioUnitario = Convert.ToDecimal(TxtPrecUnit.Text.Trim());
            var rowAffect = detalleFacturaDB.UpdateFacturaDetalle(detalleFactura);

            if (rowAffect > 0)
            {
                MessageBox.Show("Factura actualizada correctamente");
                this.updateTitle();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la factura");
            }
        }

        private void updateTitle()
        {
            this.Text = $"Detalle factura <{txtIDDETFAC.Text.Trim()}>";
        }

   

        private void txtIDProd_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtIDProd.Text))
            {
                txtIDProd.Tag = helpers.FormsValidatros.IsNumero(lblIDProducto, txtIDProd.Text);
            }
            else
            {
                lblIDProducto.ForeColor = System.Drawing.Color.Black;
            }
            this.UpdateStateForms(true);
            // VERIFICAR SI EL PRODUCTO EXISTE
        } 

        private void btnAggProd_Click(object sender, EventArgs e)
        { 
            

            //detalleFacturas.Add(detalle);

            //if (this.modo == Modo.EDITAR)
            //{
            //    CrearProducto();
            //    this.btnGuardar.Enabled = false;
            //}
            //else
            //{
            //    this.btnGuardar.Enabled = true;
            //}
            //MessageBox.Show("PRODUCTO AGREGADO CORRECTAMENTE");
            //this.UpdateStateForms(true);
        }

        // Calculamos el subtotal del producto.
        private decimal GetSubTotal()
        {

            // validar que precio unitario y cantidad estan bien
            if (!ValidateForm()) {
                return 0;
            }
            var subtotal = Convert.ToDecimal(TxtPrecUnit.Text) * Convert.ToDecimal(TxtCantidad.Text);
            LbSubTotal.Text = subtotal.ToString("N2");
            return subtotal;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(TxtCantidad.Text))
            {
                TxtCantidad.Tag = helpers.FormsValidatros.IsNumero(lblNumero, TxtCantidad.Text);
            }
            else
            {
                lblNumero.ForeColor = System.Drawing.Color.Black;
            }
            this.UpdateStateForms(true);
            GetSubTotal();
        }
         
        private void txtPrecUnit_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(TxtPrecUnit.Text))
            {
                TxtPrecUnit.Tag = helpers.FormsValidatros.IsDecimal(lblPrecioUnit, TxtPrecUnit.Text);
            }
            else
            {
                lblPrecioUnit.ForeColor = System.Drawing.Color.Black;
            }
            this.UpdateStateForms(true);
            GetSubTotal();
        }

        // valida los campos precio unitario y cantidad
        private bool ValidateForm()
        {
            bool cant = TxtCantidad.Tag != null ? (bool)TxtCantidad.Tag : false; 
            bool preciounit = TxtPrecUnit.Tag != null ? (bool)TxtPrecUnit.Tag : false;

            return cant && preciounit;
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
     
            this.isModified = isModified;
            this.lblStatusEdit.Text = this.isModified ? "Modificado" : "Sin Modificar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            // si el cliente no ha sido creado, no se puede eliminar
            if (this.modo == Modo.CREAR)
            {
                MessageBox.Show("No se puede eliminar un producto que no ha sido creado");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Eliminar Producto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // eliminar cliente
            FacturaDetallesRepositorio detalleFacturaDB = new FacturaDetallesRepositorio();
            var rowAffect = detalleFacturaDB.DeleteFacturaDetalle(this.IDFactura);
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

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            ProductoListaForm productoListaForm = new ProductoListaForm(Modo.SELECIONAR);
            productoListaForm.OnProductoSeleccionado += OnProductoSeleccionado;
            productoListaForm.ShowDialog();
        }

        private void OnProductoSeleccionado(object sender, int id) 
        { 
            ProductoRespositorio productoRespositorio = new ProductoRespositorio();
            var producto = productoRespositorio.GetProducto(id);
            txtIDProd.Text = producto.IDProducto.ToString();
            txtNombre.Text = producto.Nombre;
            txtCosto.Text = producto.Costo.ToString();
            txtPrecio.Text = producto.Precio.ToString();

            // Automaticamente el nombre del Producto se establece en descripción.
            TxtDescripcion.Text = producto.Nombre;
            TxtCantidad.Text = 1.ToString();
            TxtPrecUnit.Text = producto.Precio.ToString();

            GetSubTotal();
        }
    }
}
