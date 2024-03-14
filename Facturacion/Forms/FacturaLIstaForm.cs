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
using Facturacion.data;
using Facturacion.detallefacturas;
using Facturacion.Helpers;
using Facturacion.models;
using Facturacion.Services;

namespace Facturacion.facturas
{
    public partial class FacturaListaForm : Form
    {
        public FacturaListaForm()
        {
            InitializeComponent();
        }
        private void ListFactura_Load(object sender, EventArgs e)
        {
            // this.RefreshList();
            CampoSelecionado.SelectedIndex = 2;
        }

        private void CargarListaFactura()
        {

            FacturaRepositorio facturaRepositorio = new FacturaRepositorio();
            lblStatus.Text = "Cargando facturas...";
            // configuramos el progresbar
            toolStripProgressClientes.Visible = true;
            toolStripProgressClientes.Style = ProgressBarStyle.Marquee;

            // Recuperamos los datos de la base de datos.
            dataFacturas.DataSource = facturaRepositorio.ObtenerFacturas(txtSearch.Text, CampoSelecionado.Text);
            
            dataFacturas.Columns["TOTAL_CON_IVA"].DefaultCellStyle.Format = "N2";

            toolStripProgressClientes.Style = ProgressBarStyle.Continuous;
            toolStripProgressClientes.Visible = false;
            lblStatus.Text = "Facturas cargados"; 
        }

      
        private void Fila_DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.GetSelectedFacturaID();
            FacturaForm obj= new FacturaForm(Modo.EDITAR, id);
            obj.ShowDialog();
            this.CargarListaFactura();
        }

        private void ToolStripDeleteCliente_Click(object sender, EventArgs e)
        {
            var id = this.GetSelectedFacturaID();
            if (id == 0)
            {
                MessageBox.Show("Seleccione una factura para eliminar");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar esta factura?", "Eliminar Factura", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            ClienteRepositorio clienteDB = new ClienteRepositorio();
            var row = clienteDB.EliminarCliente(id);
            if (row > 0)
            {
                MessageBox.Show("Cliente eliminado correctamente");
                this.CargarListaFactura();
            }
        }
 
         
        private int GetSelectedFacturaID()
        {
            if (dataFacturas.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dataFacturas.SelectedRows[0].Cells["ID_FACTURA"].Value);
        }

        private void ToolStripNuevaFactura_Click(object sender, EventArgs e)
        {
            FacturaForm facturaDetails = new FacturaForm(Modo.CREAR);
            facturaDetails.ShowDialog();
            this.CargarListaFactura();
        }

        private void ToolStripDeleteFactura_Click(object sender, EventArgs e)
        {
            var id = this.GetSelectedFacturaID();
            if (id == 0)
            {
                MessageBox.Show("Seleccione una factura para eliminar");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la factura?", "Eliminar Factura", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            FacturaRepositorio facturaDB = new FacturaRepositorio();
            var row = facturaDB.DeleteFactura(id);
            if (row > 0)
            {
                MessageBox.Show("Factura eliminado correctamente");
                this.CargarListaFactura();
            }
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.CargarListaFactura();
        }
  
        private void BtnUpdateList_Click(object sender, EventArgs e)
        {
            this.CargarListaFactura();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarListaFactura();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                CargarListaFactura();
                e.Handled = true;
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
