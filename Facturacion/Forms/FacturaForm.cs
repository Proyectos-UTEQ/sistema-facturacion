using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturacion.clientes;
using Facturacion.data;
using Facturacion.detallefacturas;
using Facturacion.Helpers;
using Facturacion.models;
using Facturacion.Models;

namespace Facturacion.facturas
{
   
    public partial class FacturaForm : Form
    {
        private Modo modo = Modo.CREAR;
        private int id = 0;
        private bool isModified = false;
        private Factura _factura;

        public FacturaForm(Modo modo, int id = 0)
        {
            InitializeComponent();
            this.modo = modo;
            this.id = id;
        }

        private void FacturaDetails_Load(object sender, EventArgs e)
        {
            if (this.modo == Modo.CREAR)
            {
                this.Text = "Crear Factura";
                this.btnAplicar.Enabled = true;
                _factura = new Factura();
                dtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                // TODO: Definir el numero de la factura.
                FacturaRepositorio facturasDB = new FacturaRepositorio();
                txtNumero.Text = facturasDB.NuevoNueroFactura().ToString("D10");
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.CargarFactura();
                this.ActualizarTitulo();
            }
            this.ActualizarEstadoFormulario(false);
        }

        // Carga los datos principales de la factura.
        private void CargarFactura()
        {
            FacturaRepositorio facturaDB = new FacturaRepositorio();
            _factura = facturaDB.GetFactura(this.id);

            txtIDFactura.Text = _factura.IDFactura.ToString();

            // Establecemos los valores de cliente en el formulario.
            setCliente(_factura.IDCliente);

            dtFecha.Text = Convert.ToDateTime(_factura.FechaHora).ToString();
            txtNumero.Text = _factura.Numero.ToString("D10");
            LbTotal.Text = Convert.ToDecimal(_factura.Total).ToString("N2");
            CargarElDetalle();
        }

        // Carga el detalle de la factura.
        private void CargarElDetalle()
        {
            // FacturaDetallesRepositorio facturasDetalleDB = new FacturaDetallesRepositorio();
            lblStatusEdit.Text = "Cargando clientes...";
            // configuramos el progresbar
            toolStripProgressDetalle.Visible = true;
            toolStripProgressDetalle.Style = ProgressBarStyle.Marquee;

            //if(txtBuscar.Text.Length > 0)
            //    dataDetalleFact.DataSource = facturasDetalleDB.ObtenerFacturaDetalles(txtBuscar.Text);
            //else
            //    dataDetalleFact.DataSource = facturasDetalleDB.ObtenerDetalle(this.id); 

            // Cargamos el detalle de la factura en el datagrid.
            dataDetalleFact.DataSource = _factura.Detalles;

            dataDetalleFact.Columns["IDFacturaDetalle"].Visible = false;
            dataDetalleFact.Columns["Cantidad"].DefaultCellStyle.Format = "N2";
            dataDetalleFact.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
            dataDetalleFact.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2"; 


            toolStripProgressDetalle.Style = ProgressBarStyle.Continuous;
            toolStripProgressDetalle.Visible = false;
            lblStatusEdit.Text = "Detalle de factura cargado";
        }
         

        private void ActualizarTitulo()
        {
            this.Text = $"Factura <{dtFecha.Text.Trim()}>";
        }

         
        private void idfactura_changed(object sender, EventArgs e)
        {

            if (!helpers.FormsValidatros.IsEmpty(txtIDFactura.Text))
            {
                txtIDFactura.Tag = helpers.FormsValidatros.IsCedula(txtIDFactura, lblIDFactura);
            }
            else
            {
                lblIDFactura.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

        private void idcliente_changed(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtIDCliente.Text))
            {
                txtIDCliente.Tag = helpers.FormsValidatros.IsTextLength(txtIDCliente, lblIDCliente, 50);
            }
            else
            {
                lblFecha.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

      

        
          
        private void dtFecha_ValueChanged(object sender, EventArgs e)
        { 
            dtFecha.Tag = helpers.FormsValidatros.IsDate(dtFecha.Text); 
            this.ActualizarEstadoFormulario(true);
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

            this.ActualizarEstadoFormulario(true);
        }

       
 
          
        private void btnAggProd_Click(object sender, EventArgs e)
        {
            FacturaDetallesForm clienteDetails;
            _factura.IDCliente = Convert.ToInt32(txtIDCliente.Text.Trim());
            _factura.FechaHora = dtFecha.Value;
            _factura.Numero = Convert.ToInt32(txtNumero.Text.Trim());
            _factura.Total = Convert.ToDecimal(LbTotal.Text.Trim()); 
            if(this.modo == Modo.CREAR)
            {
               clienteDetails = new FacturaDetallesForm(_factura, Modo.CREAR, id);
            }else
            {
                clienteDetails = new FacturaDetallesForm(_factura, Modo.EDITAR, id);
            }
             
            clienteDetails.ShowDialog(); 
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            // si el cliente no ha sido creado, no se puede eliminar
            if (this.modo == Modo.CREAR)
            {
                MessageBox.Show("No se puede eliminar una factura que no ha sido creada");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la factura?", "Eliminar Factura", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // eliminar cliente
            FacturaRepositorio facturaDB = new FacturaRepositorio();
            var rowAffect = facturaDB.DeleteFactura(this.id);
            if (rowAffect > 0)
            {
                MessageBox.Show("Factura eliminada correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la factura");
            }
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (!this.ValidateForm())
            {
                MessageBox.Show("Formulario invalido");
                return;
            }

            if (!TieneProductosEnDetalles())
            {
                MessageBox.Show("No tiene productos en el detalle");
                return;
            }

            if (this.modo == Modo.CREAR)
            {
                this.CrearFactura();
            }
            else
            {
                // TODO: Actualizar el usuario.
                this.EditarFactura();
            }

            this.ActualizarEstadoFormulario(false);
            this.Close();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.CargarElDetalle();
        }

        private void dataDetalleFact_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IDS ids = new IDS(); 
            ids = GetSelectedFacturaDetalleIDs(); 
            FacturaDetallesForm obj = new FacturaDetallesForm(Modo.EDITAR, ids, this.id);
            obj.ShowDialog();
        }
        private IDS GetSelectedFacturaDetalleIDs()
        {
            if (dataDetalleFact.SelectedRows.Count == 0)
            {
                return null;
            }
            IDS obj = new IDS();

            obj.IDFactura = Convert.ToInt32(dataDetalleFact.SelectedRows[0].Cells["IDFactura"].Value);
            obj.IDProducto = Convert.ToInt32(dataDetalleFact.SelectedRows[0].Cells["IDProducto"].Value);

            return obj;
        }

        private void CrearFactura()
        {
            FacturaRepositorio facturaDB = new FacturaRepositorio();
            FacturaDetallesRepositorio facturaDetallesRepositorio = new FacturaDetallesRepositorio();

            _factura.IDCliente = Convert.ToInt32(txtIDCliente.Text.Trim());
            _factura.FechaHora = dtFecha.Value;
            _factura.Numero = Convert.ToInt32(txtNumero.Text.Trim());
            _factura.Total = Convert.ToDecimal(LbTotal.Text.Trim());

            // Registro de la factura en la base de datos.
            _factura.IDFactura = facturaDB.RegistrarNuevaFactura(_factura);

            // Registrar el detalle en base a la factura.
            facturaDetallesRepositorio.RegistrarDetalleFactura(_factura);


            // actualizamos el id del cliente en el formulario
            txtIDCliente.Text = _factura.IDCliente.ToString();
            this.ActualizarTitulo();
            this.modo = Modo.EDITAR;
        }

        private void EditarFactura()
        {
            FacturaRepositorio facturaDB = new FacturaRepositorio();
            Factura factura = new Factura();

            factura.IDFactura = Convert.ToInt32(txtIDFactura.Text.Trim());
            factura.IDCliente = Convert.ToInt32(txtIDCliente.Text.Trim());
            factura.FechaHora = dtFecha.Value;
            factura.Numero = Convert.ToInt32(txtNumero.Text.Trim());
            factura.Total = Convert.ToDecimal(LbTotal.Text.Trim());
            var rowAffect = facturaDB.UpdateFactura(factura);
            if (rowAffect > 0)
            {
                MessageBox.Show("Factura actualizada correctamente");
                this.ActualizarTitulo();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la factura");
            }
        }
        private void ActualizarEstadoFormulario(bool isModified)
        {
            // controlar el estado de los botones
            if (this.modo == Modo.CREAR)
            {
                this.btnRemover.Enabled = false;
                
            }
            else
            {
                this.btnRemover.Enabled = true;
                this.txtIDCliente.Enabled = false;
            }

            // controlar el estado del boton aplicar
            if (this.ValidateForm())
            { 
                
            }
            else
            { 
                
            }
            this.isModified = isModified;
            this.lblStatusEdit.Text = this.isModified ? "Modificado" : "Sin Modificar";
        }

        private bool ValidateForm()
        {
            bool numero = txtNumero.Tag != null ? (bool)txtNumero.Tag : false;
            bool total = Convert.ToDecimal(LbTotal.Text) > 0;

            return numero && total;
        }

        private bool TieneProductosEnDetalles()
        {
            return _factura.Detalles.Count > 0;
        }

        private void txtIDCliente_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtIDCliente.Text))
            {
                txtIDCliente.Tag = helpers.FormsValidatros.IsNumero(lblIDCliente, txtIDCliente.Text);
            }
            else
            {
                lblIDCliente.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblIDCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ClienteListaForm clienteListaForm = new ClienteListaForm(Modo.SELECIONAR);
            clienteListaForm.OnClienteSelecionado += onClienteSelecionado;
            clienteListaForm.ShowDialog();
        }

        // resive el valor del cliente selecionado.
        private void onClienteSelecionado(object sender, int id) {
            setCliente(id);
        }

        private void setCliente(int id)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            var cliente = clienteRepositorio.ObtenerCliente(id);
            txtIDCliente.Text = id.ToString();
            txtCedula.Text = cliente.Cedula;
            txtNombres.Text = cliente.Nombres;
            txtApellidos.Text = cliente.Apellidos;
        }

        private void lblNumero_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FacturaDetallesForm facturaDetallesForm = new FacturaDetallesForm(Modo.CREAR, id);
            facturaDetallesForm.OnFacturaDetallesChanged += OnFacturaDetalle;
            facturaDetallesForm.ShowDialog();
        }

        private void OnFacturaDetalle(object sender, FacturaDetalles detalles)
        {
            _factura.Detalles.Add(detalles);
            dataDetalleFact.DataSource = null;
            dataDetalleFact.DataSource = _factura.Detalles;

            // TODO: Recalcular el total.
            CalcularTotal();
        }

        private void CalcularTotal() 
        { 
            _factura.Total = _factura.Detalles.Sum(d => d.SubTotal);
            LbTotal.Text = _factura.Total.ToString("N2");
        }
    }
}
