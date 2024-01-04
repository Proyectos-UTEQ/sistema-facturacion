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
            this.RefreshList();
        }

        private void RefreshList()
        {
            
            FacturacionService service = new FacturacionService();
            lblStatus.Text = "Cargando facturas...";
            // configuramos el progresbar
            toolStripProgressClientes.Visible = true;
            toolStripProgressClientes.Style = ProgressBarStyle.Marquee;


            dataFacturas.DataSource = service.ObtenerFacturas(txtSearch.Text);
            dataFacturas.Columns["TOTAL"].DefaultCellStyle.Format = "N2";
            dataFacturas.Columns["Id"].Visible = false;
            dataFacturas.Columns["IDCliente"].Visible = false;
            dataFacturas.Columns["Numero"].HeaderText = "Número de factura";
            dataFacturas.Columns["Fecha"].HeaderText = "Creada";
            dataFacturas.Columns["Cedula"].HeaderText = "Cédula del cliente";
            dataFacturas.Columns["Cliente"].HeaderText = "Cliente";
            dataFacturas.Columns["Cliente"].Width = 200;



            toolStripProgressClientes.Style = ProgressBarStyle.Continuous;
            toolStripProgressClientes.Visible = false;
            lblStatus.Text = "Facturas cargados"; 
        }

      
        private void Fila_DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.GetSelectedFacturaID();
            FacturaForm obj= new FacturaForm(Modo.EDITAR, id);
            obj.ShowDialog();
            this.RefreshList();
        }
        private void toolStripDeleteCliente_Click(object sender, EventArgs e)
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
                this.RefreshList();
            }
        }
 
         
        private int GetSelectedFacturaID()
        {
            if (dataFacturas.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dataFacturas.SelectedRows[0].Cells["Id"].Value);
        }

        private void toolStripNuevaFactura_Click(object sender, EventArgs e)
        {
            FacturaForm facturaDetails = new FacturaForm(Modo.CREAR);
            facturaDetails.ShowDialog();
            this.RefreshList();
        }

        private void toolStripDeleteFactura_Click(object sender, EventArgs e)
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
                this.RefreshList();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.RefreshList();
        }
  
        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }
         

    }
}
