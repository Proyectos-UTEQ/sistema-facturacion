using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
                this.btnImprimir.Enabled = false;
                _factura = new Factura();
                FacturaRepositorio facturasDB = new FacturaRepositorio();
                txtNumero.Text = facturasDB.NuevoNueroFactura().ToString("D10");

                dtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.CargarFactura();
                this.ActualizarTitulo();
            }
            this.ActualizarEstadoFormulario(false);
            
            //SetTaxIndexControllers();
        }

       
        private void SetTaxIndexControllers()
        {
            dataDetalleFact.TabStop = false;
            dtFecha.TabIndex = 0;
            
            // Grupo de cliente
            groupBoxCliente.TabIndex = 1;
            btnBuscarCliente.TabIndex = 1;

            btnAplicar.TabIndex = 2;
            btnCancelar.TabIndex = 3;
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
                this.ImprimirFactura();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirFactura();
        }

         

        private void ImprimirFactura()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fontTitulo = new Font("Arial", 32, FontStyle.Bold);
            Font fontCabecera = new Font("Arial", 16, FontStyle.Bold);
            Font fontCuerpo = new Font("Arial", 12);
            SolidBrush celesteBrush = new SolidBrush(Color.LightSkyBlue);

            float x = 20;
            float y = 20;


            e.Graphics.DrawString("NisaSoft", fontTitulo, celesteBrush, x, y);


            e.Graphics.DrawString("Factura", fontTitulo, celesteBrush, e.PageBounds.Width - 200, y);


            y += 60;
            e.Graphics.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);


            y += 50;
            e.Graphics.DrawString("Cliente:", fontCabecera, Brushes.Black, x, y);
            y += 30;

            e.Graphics.DrawString("  Nombre: ", fontCuerpo, Brushes.Black, x, y);
            e.Graphics.DrawString($"{txtNombres.Text}", fontCuerpo, Brushes.Black, x + 80, y);
            y += 20;

            e.Graphics.DrawString("  Apellido: ", fontCuerpo, Brushes.Black, x, y);
            e.Graphics.DrawString($"{txtApellidos.Text}", fontCuerpo, Brushes.Black, x + 80, y);
            y += 20;

            e.Graphics.DrawString("  Cedula: ", fontCuerpo, Brushes.Black, x, y);
            e.Graphics.DrawString($"{txtCedula.Text}", fontCuerpo, Brushes.Black, x + 80, y);
            y += 30;


            e.Graphics.DrawString($"N Factura: {_factura.IDFactura}", fontCuerpo, Brushes.Black, e.PageBounds.Width - 260, 100);
            e.Graphics.DrawString($"Fecha: {_factura.FechaHora}", fontCuerpo, Brushes.Black, e.PageBounds.Width - 260, 120);


            y += 20;
            e.Graphics.DrawString("Detalle de la Compra:", fontCabecera, Brushes.Black, x, y);
            y += 30;

            // Encabezados del DataGridView
            fontCabecera = new Font("Arial", 10, FontStyle.Bold);
            int[] columnWidths = { 120, 80, 100, 130, 80, 80, 120 };
            int[] valueWidths = { 100, 80, 100, 130, 80, 80, 120 };
            int totalWidth = columnWidths.Sum();


            if (totalWidth > e.PageBounds.Width - 40)
            {
                float scaleFactor = (e.PageBounds.Width - 40) / (float)totalWidth;
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    columnWidths[i] = (int)(columnWidths[i] * scaleFactor);
                }
            }

            for (int i = 0; i < dataDetalleFact.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataDetalleFact.Columns[i].HeaderText, fontCabecera, Brushes.Black, x, y);
                x += columnWidths[i];
            }


            y += 20;
            e.Graphics.DrawLine(Pens.Black, 20, y, e.PageBounds.Width - 20, y);


            foreach (DataGridViewRow row in dataDetalleFact.Rows)
            {
                x = 20;
                y += 20;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == 3)
                    {
                        e.Graphics.DrawString(row.Cells[i].Value.ToString(), fontCabecera, Brushes.Black, x + 35, y);
                    }
                    else if (i == 0)
                    {
                        e.Graphics.DrawString(row.Cells[i].Value.ToString(), fontCuerpo, Brushes.Black, x + 75, y);
                    }
                    else if (i == 4 || i == 5 || i == 6)
                    {
                        string formattedValue = Math.Round(Convert.ToDecimal(row.Cells[i].Value), 2).ToString();
                        e.Graphics.DrawString(formattedValue, fontCuerpo, Brushes.Black, new RectangleF(x, y, columnWidths[i], 20), new StringFormat { Alignment = StringAlignment.Far });
                    }
                    else
                    {
                        e.Graphics.DrawString(row.Cells[i].Value.ToString(), fontCuerpo, Brushes.Black, new RectangleF(x, y, columnWidths[i], 20), new StringFormat { Alignment = StringAlignment.Far });
                    }

                    x += valueWidths[i];
                }
            }

            // Línea divisoria
            y += 30;
            e.Graphics.DrawLine(Pens.Black, 20, y, e.PageBounds.Width - 20, y);

            // Imprimir el total en la esquina inferior derecha
            y += 20;
            fontCabecera = new Font("Arial", 26, FontStyle.Bold);
            e.Graphics.DrawString($"Total: {_factura.Total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}", fontCabecera, Brushes.Black, e.PageBounds.Width - 350, y);
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
            FacturaDetallesForm facturaDetallesForm = new FacturaDetallesForm(Modo.CREAR, id);
            facturaDetallesForm.OnFacturaDetallesChanged += OnFacturaDetalle;
            facturaDetallesForm.ShowDialog();
        }
    }
}
