﻿using System;
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
using Facturacion.models;
using Facturacion.Models;

namespace Facturacion.facturas
{
    public enum Modo
    {
        CREAR,
        EDITAR
    }
    public partial class FacturaForm : Form
    {
        private Modo modo = Modo.CREAR;
        private int id = 0;
        private bool isModified = false;
        Factura factura = new Factura();

        public FacturaForm(Modo modo, int id = 0)
        {
            InitializeComponent();
            this.modo = modo;
            this.id = id;
        }
         
        private void loadFactura()
        {
            FacturaRepositorio facturaDB = new FacturaRepositorio();
            Factura factura = facturaDB.GetFactura(this.id);
            txtIDFactura.Text = factura.IDFactura.ToString();
            // Establecemos los valores de cliente en el formulario.
            setCliente(factura.IDCliente);
            
            dtFecha.Text = Convert.ToDateTime(factura.FechaHora).ToString(); 
            txtNumero.Text = factura.Numero.ToString("D10");
            txtTotal.Text = Convert.ToDecimal(factura.Total).ToString("N2");
        }

        private void FacturaDetails_Load(object sender, EventArgs e)
        {
            if (this.modo == Modo.CREAR)
            {
                this.Text = "Crear Factura";
                this.btnAplicar.Enabled = false;
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.loadFactura();
                this.updateTitle();
            }
            this.UpdateStateForms(false);
            this.RefreshList();
        }
        private async void RefreshList()
        {
            FacturaDetallesRepositorio facturasDetalleDB = new FacturaDetallesRepositorio();
            lblStatusEdit.Text = "Cargando clientes...";
            // configuramos el progresbar
            toolStripProgressDetalle.Visible = true;
            toolStripProgressDetalle.Style = ProgressBarStyle.Marquee;

            // esperamos a la db
            await Task.Delay(500);
            if(txtBuscar.Text.Length > 0)
                dataDetalleFact.DataSource = facturasDetalleDB.ObtenerFacturaDetalles(txtBuscar.Text);
            else
                dataDetalleFact.DataSource = facturasDetalleDB.GetListFacturaDetalle(this.id); 

            dataDetalleFact.Columns["IDFacturaDetalle"].Visible = false;
            dataDetalleFact.Columns["Numero"].DefaultCellStyle.Format = "N2";
            dataDetalleFact.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
            dataDetalleFact.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2"; 

            toolStripProgressDetalle.Style = ProgressBarStyle.Continuous;
            toolStripProgressDetalle.Visible = false;
            lblStatusEdit.Text = "Detalle de factura cargado";
        }
         

        private void updateTitle()
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

            this.UpdateStateForms(true);
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

            this.UpdateStateForms(true);
        }

      

        private void numero_changed(object sender, EventArgs e)
        { 
            if (!helpers.FormsValidatros.IsEmpty(txtNumero.Text))
            {
                txtNumero.Tag = helpers.FormsValidatros.IsNumeroLength(txtTotal, lblTotal, 10);
            }
            else
            {
                lblNumero.ForeColor = System.Drawing.Color.Black;
            }

            this.UpdateStateForms(true);
        }
          
        private void dtFecha_ValueChanged(object sender, EventArgs e)
        { 
            dtFecha.Tag = helpers.FormsValidatros.IsDate(dtFecha.Text); 
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

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtTotal.Text))
            { 
                txtTotal.Tag = helpers.FormsValidatros.IsNumero(lblTotal, txtTotal.Text);
            }
            else
            {
                lblTotal.ForeColor = System.Drawing.Color.Black;
            }

            this.UpdateStateForms(true);
        }
 
          
        private void btnAggProd_Click(object sender, EventArgs e)
        {
            FacturaDetallesForm clienteDetails;
            factura.IDCliente = Convert.ToInt32(txtIDCliente.Text.Trim());
            factura.FechaHora = dtFecha.Value;
            factura.Numero = Convert.ToInt32(txtNumero.Text.Trim());
            factura.Total = Convert.ToDecimal(txtTotal.Text.Trim()); 
            if(this.modo== Modo.CREAR)
            {
               clienteDetails = new FacturaDetallesForm(factura, Facturacion.detallefacturas.Modo.CREAR, this.id);
            }else
            {
                clienteDetails = new FacturaDetallesForm(factura, Facturacion.detallefacturas.Modo.EDITAR, this.id);
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

            if (this.modo == Modo.CREAR)
            {
                this.CrearFactura();
            }
            else
            {
                // TODO: Actualizar el usuario.
                this.EditarFactura();
            }

            this.UpdateStateForms(false);
            this.Close();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.RefreshList();
        }

        private void dataDetalleFact_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IDS ids = new IDS(); 
            ids = GetSelectedFacturaDetalleIDs(); 
            FacturaDetallesForm obj = new FacturaDetallesForm(Facturacion.detallefacturas.Modo.EDITAR, ids, this.id);
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

            factura.IDCliente = Convert.ToInt32(txtIDCliente.Text.Trim());
            factura.FechaHora = dtFecha.Value;
            factura.Numero = Convert.ToInt32(txtNumero.Text.Trim());
            factura.Total = Convert.ToDecimal(txtTotal.Text.Trim());
            factura.IDCliente = facturaDB.AddFactura(factura);

            // actualizamos el id del cliente en el formulario
            txtIDCliente.Text = factura.IDCliente.ToString();
            this.updateTitle();
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
            factura.Total = Convert.ToDecimal(txtTotal.Text.Trim());
            var rowAffect = facturaDB.UpdateFactura(factura);
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
        private void UpdateStateForms(bool isModified)
        {
            // controlar el estado de los botones
            if (this.modo == Modo.CREAR)
            {
                this.btnRemover.Enabled = false;
                this.btnAggProd.Enabled = false;
            }
            else
            {
                this.btnRemover.Enabled = true;
                this.txtIDCliente.Enabled = false;
            }

            // controlar el estado del boton aplicar
            if (this.ValidateForm())
            { 
                this.btnAggProd.Enabled = true;
            }
            else
            { 
                this.btnAggProd.Enabled = false;
            }
            this.isModified = isModified;
            this.lblStatusEdit.Text = this.isModified ? "Modificado" : "Sin Modificar";
        }

        private bool ValidateForm()
        {
            bool fecha = dtFecha.Tag != null ? (bool)dtFecha.Tag : false;
            bool numero = txtNumero.Tag != null ? (bool)txtNumero.Tag : false;
            bool total = txtTotal.Tag != null ? (bool)txtTotal.Tag : false;

            return fecha && numero && total;
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

            this.UpdateStateForms(true);
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
            ClienteListaForm clienteListaForm = new ClienteListaForm(clientes.Modo.SELECIONAR);
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
    }
}
