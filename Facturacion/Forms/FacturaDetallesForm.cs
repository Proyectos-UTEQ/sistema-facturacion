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
using Facturacion.Models;

namespace Facturacion.detallefacturas
{
    public enum Modo
    {
        CREAR,
        EDITAR
    }

    public partial class FacturaDetallesForm : Form
    {
        List<DetalleFacturas> detalleFacturas = new List<DetalleFacturas>();
        DetalleFacturas detalle = new DetalleFacturas();
        Factura factura = new Factura();
        private Modo modo = Modo.CREAR; 
        private int id = 0;
        private int idFactura = 0;
        private int idProducto = 0;
        private bool isModified = false;
        public FacturaDetallesForm(Modo modo, int id = 0)
        {
            InitializeComponent();
            this.id = id;
            this.modo = modo;
        }

        public FacturaDetallesForm(Factura factura, Modo modo, int id=0)
        {
            InitializeComponent();
            this.id = id;
            this.modo = modo;
            this.factura = factura; 
        }
        public FacturaDetallesForm(Modo modo, IDS ids, int id)
        {
            InitializeComponent();
            this.id= id;
            this.idFactura = ids.IDFactura;
            this.idProducto = ids.IDProducto;
            this.modo = modo; 
        }


        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            if (this.modo == Modo.CREAR)
            {
                this.Text = "Crear Detalle factura"; 
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
            DetalleFacturas facturasDetalle = facturasDetalleDB.GetFacturaDetalle(this.idFactura,this.idProducto);  

            txtIDDETFAC.Text = facturasDetalle.IDFacturaDetalle.ToString();
            txtIDFact.Text = facturasDetalle.IDFactura.ToString();
            txtIDProd.Text = facturasDetalle.IDProducto.ToString();
            txtNumero.Text = facturasDetalle.Numero.ToString("N2"); 
            txtPrecUnit.Text = facturasDetalle.PrecioUnitario.ToString("N2"); 
        }

        private void Aplicar_Click(object sender, EventArgs e)
        {
            if (!this.ValidateForm())
            {
                MessageBox.Show("Formulario invalido");
                return;
            }
            if (this.modo == Modo.CREAR)
            {
                this.CrearFactura();
            }
            else
            {
                this.EditarFactura();
            }

            this.UpdateStateForms(false);
            MessageBox.Show("SE A REALIZADO LA VENTA EXITOSAMENTE");
            this.Close();
        }

        private void CrearFactura()
        {
            FacturaDetallesRepositorio detalleFacturaDB = new FacturaDetallesRepositorio(); 
            FacturaRepositorio facturaDB = new FacturaRepositorio();

            // enviamos los datos a detalle factura
            // esperamos a la db  
            facturaDB.AddFactura(this.factura);
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
            detalleFacturaDB.AddFacturaDetalle(detalleFacturas, this.id);

            this.updateTitle();
            this.modo = Modo.EDITAR;
        }

        private void EditarFactura()
        {
            FacturaDetallesRepositorio detalleFacturaDB = new FacturaDetallesRepositorio();

            DetalleFacturas detalleFactura = new DetalleFacturas();
            detalleFactura.IDFactura = Convert.ToInt32(txtIDFact.Text.Trim());
            detalleFactura.IDProducto = Convert.ToInt32(txtIDProd.Text.Trim());
            detalleFactura.Numero = Convert.ToDecimal(txtNumero.Text.Trim()); 
            detalleFactura.PrecioUnitario = Convert.ToDecimal(txtPrecUnit.Text.Trim());
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
            DetalleFacturas detalle = new DetalleFacturas();
             
            detalle.IDProducto= Convert.ToInt32(txtIDProd.Text);
            detalle.Numero= Convert.ToDecimal(txtNumero.Text); 
            detalle.PrecioUnitario = Convert.ToDecimal(txtPrecUnit.Text);
             
            detalleFacturas.Add(detalle);

            if(this.modo==Modo.EDITAR)
            {
                CrearProducto();
                this.btnAplicar.Enabled = false;
            }
            else
            {
                this.btnAplicar.Enabled = true;
            }
            MessageBox.Show("PRODUCTO AGREGADO CORRECTAMENTE");
            this.UpdateStateForms(true); 
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtNumero.Text))
            {
                txtNumero.Tag = helpers.FormsValidatros.IsNumero(lblNumero, txtNumero.Text);
            }
            else
            {
                lblNumero.ForeColor = System.Drawing.Color.Black;
            }
            this.UpdateStateForms(true);
        }
         
        private void txtPrecUnit_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtPrecUnit.Text))
            {
                txtPrecUnit.Tag = helpers.FormsValidatros.IsNumero(lblPrecioUnit, txtPrecUnit.Text);
            }
            else
            {
                lblPrecioUnit.ForeColor = System.Drawing.Color.Black;
            }
            this.UpdateStateForms(true);
        }

        private bool ValidateForm()
        {
            bool cant = txtNumero.Tag != null ? (bool)txtNumero.Tag : false; 
            bool preciounit = txtPrecUnit.Tag != null ? (bool)txtPrecUnit.Tag : false;

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
            var rowAffect = detalleFacturaDB.DeleteFacturaDetalle(this.id);
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
