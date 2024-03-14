using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturacion.clientes;
using Facturacion.data;
using Facturacion.DataAccess.Repositorios;
using Facturacion.detallefacturas;
using Facturacion.Forms;
using Facturacion.Helpers;
using Facturacion.models;
using Facturacion.Models;
using Facturacion.productos;

namespace Facturacion.facturas
{
   
    public partial class FacturaForm : Form
    {
        private Modo modo = Modo.CREAR;
        private int id = 0;
        private bool isModified = false;
        private Factura _factura;
        private ConfigIVA _configIVA;

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
                FacturaRepositorio facturasDB = new FacturaRepositorio();
                _factura.NUMERO_FACTURA = facturasDB.NuevoNueroFactura();
                txtNumero.Text = _factura.NUMERO_FACTURA.ToString("D10");
                btnReporte.Enabled = false;

                dtFecha.Value = DateTime.Now;
                ActualizarConfigIVA(dtFecha.Value);
                
            }
            else if (this.modo == Modo.EDITAR)
            {
                btnReporte.Enabled = true;
                CargarFactura();
                ActualizarTitulo();
                RecalcularResultadoDeFactura();
            }
            this.ActualizarEstadoFormulario(false);
            
            //SetTaxIndexControllers();
        }

        private void ActualizarConfigIVA(DateTime date) 
        {
            ConfigIVARespositorio configIVARespositorio = new ConfigIVARespositorio();
            _configIVA = configIVARespositorio.ObtenerConfigIVAByDate(date);
            lbIVAConfig.Text = _configIVA.VALOR_IVA.ToString("0.00%", System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
            _factura.ID_CONFIG_IVA = _configIVA.ID_IVA;
            RecalcularResultadoDeFactura();
        }

        // Carga los datos principales de la factura.
        private void CargarFactura()
        {
            FacturaRepositorio facturaDB = new FacturaRepositorio();
            _factura = facturaDB.GetFactura(this.id);

            ActualizarConfigIVA(_factura.FechaHora);

            txtIDFactura.Text = _factura.IDFactura.ToString();

            // Establecemos los valores de cliente en el formulario.
            SetCliente(_factura.IDCliente);

            dtFecha.Text = Convert.ToDateTime(_factura.FechaHora).ToString();
            txtNumero.Text = _factura.NUMERO_FACTURA.ToString("D10");
            LbTotalConIVA.Text = Convert.ToDecimal(_factura.TOTAL_CON_IVA).ToString("N2");
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
            dataDetalleFact.DataSource = null;
            dataDetalleFact.DataSource = _factura.Detalles;

            dataDetalleFact.Columns["IDFacturaDetalle"].Visible = false;
            dataDetalleFact.Columns["Cantidad"].DefaultCellStyle.Format = "N2";
            dataDetalleFact.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
            dataDetalleFact.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2"; 

            dataDetalleFact.Columns["IDFactura"].ReadOnly = true;
            dataDetalleFact.Columns["IDProducto"].ReadOnly = true;
            dataDetalleFact.Columns["Descripcion"].ReadOnly = true;
            dataDetalleFact.Columns["SubTotal"].ReadOnly = true;
            


            toolStripProgressDetalle.Style = ProgressBarStyle.Continuous;
            toolStripProgressDetalle.Visible = false;
            lblStatusEdit.Text = "Detalle de factura cargado";
            CalcularTotal();
        }
         

        private void ActualizarTitulo()
        {
            this.Text = $"Factura <{dtFecha.Text.Trim()}>";
        }

         
        private void IDfactura_changed(object sender, EventArgs e)
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

        private void IDCliente_changed(object sender, EventArgs e)
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
          
        private void DataGridFecha_ValueChanged(object sender, EventArgs e)
        { 
            dtFecha.Tag = helpers.FormsValidatros.IsDate(dtFecha.Text); 
            this.ActualizarEstadoFormulario(true);
            ActualizarConfigIVA(dtFecha.Value);
        }

        private void TxtNumero_TextChanged(object sender, EventArgs e)
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
          
        private void BtnAggProd_Click(object sender, EventArgs e)
        {
            FacturaDetallesForm clienteDetails;
            _factura.IDCliente = Convert.ToInt32(txtIDCliente.Text.Trim());
            _factura.FechaHora = dtFecha.Value;
            _factura.NUMERO_FACTURA = Convert.ToInt32(txtNumero.Text.Trim());
            _factura.TOTAL_CON_IVA = Convert.ToDecimal(LbTotalConIVA.Text.Trim()); 
            if(this.modo == Modo.CREAR)
            {
               clienteDetails = new FacturaDetallesForm(_factura, Modo.CREAR, id);
            }else
            {
                clienteDetails = new FacturaDetallesForm(_factura, Modo.EDITAR, id);
            }
             
            clienteDetails.ShowDialog(); 
        }

        private void BtnRemover_Click(object sender, EventArgs e)
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

        private void BtnAplicar_Click(object sender, EventArgs e)
        {

            if (!TieneProductosEnDetalles())
            {
                MessageBox.Show("No tiene productos en el detalle");
                return;
            }

            if (this.modo == Modo.CREAR)
            {
                CrearFactura();
            }
            else
            {
                EditarFactura();
            }

            this.ActualizarEstadoFormulario(false);
            btnReporte.Enabled = true;
        }

        private void TxtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.CargarElDetalle();
        }

        private void DataDetalleFact_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
            
            _factura.FechaHora = dtFecha.Value;
            RecalcularResultadoDeFactura();
            var rowAffect = facturaDB.UpdateFactura(_factura);
            if (rowAffect > 0)
            {
                MessageBox.Show("Factura actualizada correctamente");
                this.ActualizarTitulo();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la factura");
            }

            // agregar el nuevo detalle factura que el usuario agrego.
            FacturaDetallesRepositorio facturaDetallesRepositorio = new FacturaDetallesRepositorio();
            facturaDetallesRepositorio.RegistrarDetalleFactura(_factura);
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

            
            this.isModified = isModified;
            this.lblStatusEdit.Text = this.isModified ? "Modificado" : "Sin Modificar";
        }

  

        private bool TieneProductosEnDetalles()
        {
            return _factura.Detalles.Count > 0;
        }

        private void TxtIDCliente_TextChanged(object sender, EventArgs e)
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            ClienteListaForm clienteListaForm = new ClienteListaForm(Modo.SELECIONAR);
            clienteListaForm.OnClienteSelecionado += OnClienteSelecionado;
            clienteListaForm.ShowDialog();
        }

        // resive el valor del cliente selecionado.
        private void OnClienteSelecionado(object sender, int id) {
            SetCliente(id);
        }

        private void SetCliente(int id)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            var cliente = clienteRepositorio.ObtenerCliente(id);
            txtIDCliente.Text = id.ToString();
            txtCedula.Text = cliente.Cedula;
            txtNombres.Text = cliente.Nombres;
            txtApellidos.Text = cliente.Apellidos;
            _factura.Cliente = cliente;
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
            _factura.TOTAL_CON_IVA = _factura.Detalles.Sum(d => d.SubTotal);
            LbTotalConIVA.Text = _factura.TOTAL_CON_IVA.ToString("N2");
        }
        
        private void FacturaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                Close();
            }
        }

        private void btnAddProducto_Click(object sender, EventArgs e)
        {
            //FacturaDetallesForm facturaDetallesForm = new FacturaDetallesForm(Modo.CREAR, id);
            //facturaDetallesForm.OnFacturaDetallesChanged += OnFacturaDetalle;
            //facturaDetallesForm.ShowDialog();

            ProductoListaForm productoListaForm = new ProductoListaForm(Modo.SELECIONAR);
            productoListaForm.OnProductoSeleccionado += OnProductoSeleccionado;
            productoListaForm.ShowDialog();
        }

        // Controlamos el evento para recuperar el producto selecionado.
        private void OnProductoSeleccionado(object sender, int id)
        {
            ProductoRespositorio productoRespositorio = new ProductoRespositorio();
            var producto = productoRespositorio.GetProducto(id);

            // agregar el producto recuperado en el detalle de la factura
            _factura.Detalles.Add(
                new FacturaDetalles() { 
                    IDProducto = id, 
                    Descripcion = producto.Nombre,
                    Cantidad = 1, 
                    PrecioUnitario = producto.Precio, 
                    SubTotal = producto.Precio * 1,
                });

            CargarElDetalle();
            RecalcularResultadoDeFactura();
        }

        private void DataDetalleFact_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataDetalleFact.Columns["Cantidad"].Index ||
                e.ColumnIndex == dataDetalleFact.Columns["PrecioUnitario"].Index) 
            {
                CalcularSubTotal(e.RowIndex);
            }
        }

        private void CalcularSubTotal(int rowIndex)
        { 
            
            decimal cantidad = Convert.ToDecimal(dataDetalleFact.Rows[rowIndex].Cells["Cantidad"].Value);
            decimal precioUnitario = Convert.ToDecimal(dataDetalleFact.Rows[rowIndex].Cells["PrecioUnitario"].Value);

            // Calcula el nuevo total
            decimal subtotal = cantidad * precioUnitario;

            // Actualiza el valor en la columna "Total" de la misma fila
            dataDetalleFact.Rows[rowIndex].Cells["SubTotal"].Value = subtotal;
            RecalcularResultadoDeFactura();
        }

        // Recalcula el subtotal, el total y el IVA
        private void RecalcularResultadoDeFactura()
        {
            decimal subTotal = 0;
             // Itera a través de todas las filas y suma los valores de la columna "Total"
            foreach (DataGridViewRow row in dataDetalleFact.Rows)
            {
                if (!row.IsNewRow) // Verifica si la fila no es una fila nueva
                {
                    subTotal += Convert.ToDecimal(row.Cells["SubTotal"].Value);
                }
            }

            // Actualiza el valor en el Label lbTotal
            var iva = subTotal * _configIVA.VALOR_IVA;
            var totalConIva = subTotal + iva;

            _factura.SUB_TOTAL = subTotal;
            _factura.IVA = iva;
            _factura.TOTAL_CON_IVA = totalConIva;
            _factura.CONFIG_IVA = _configIVA.VALOR_IVA;

            lbSubTotal.Text = subTotal.ToString("C", CultureInfo.GetCultureInfo("es-EC"));
            lbIVA.Text = iva.ToString("C", CultureInfo.GetCultureInfo("es-EC"));
            LbTotalConIVA.Text = totalConIva.ToString("C", CultureInfo.GetCultureInfo("es-EC"));
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            ImprimirForm imprimirForm = new ImprimirForm(_factura);
            imprimirForm.ShowDialog();
        }

        // Evento para que se muestre el menu contextual del datagridview
        private void DataDetalleFact_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) { 
                Point mouseLocation = dataDetalleFact.PointToClient(Cursor.Position);

                dataDetalleFact.ClearSelection();
                dataDetalleFact.Rows[e.RowIndex].Selected = true;

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Eliminar", null, EliminarDetalle_Click);
                menu.Show(dataDetalleFact, mouseLocation);
            }
        }

        private void EliminarDetalle_Click(object sender, EventArgs e) {
            // Recuperar la fina seleccionada
            var idDetalle = Convert.ToInt32(dataDetalleFact.SelectedRows[0].Cells["IDFacturaDetalle"].Value);

            if (idDetalle > 0)
            {
                FacturaDetallesRepositorio facturasDetalleDB = new FacturaDetallesRepositorio();
                facturasDetalleDB.DeleteFacturaDetalle(idDetalle);
            }
            _factura.Detalles.Remove(_factura.Detalles.Find(x => x.IDFacturaDetalle == idDetalle));
            CargarElDetalle();

        }

     

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbIVAConfig_Click(object sender, EventArgs e)
        {

        }
    }
}

