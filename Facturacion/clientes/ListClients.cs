using Facturacion.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.clientes
{
    public partial class ListClients : Form
    {
        public ListClients()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListCustomers_Load(object sender, EventArgs e)
        {
            this.RefreshList();
        }

        private async void RefreshList()
        {
            ClienteDB clienteDB = new ClienteDB();
            lblStatus.Text = "Cargando clientes...";
            // configuramos el progresbar
            toolStripProgressClientes.Visible = true;
            toolStripProgressClientes.Style = ProgressBarStyle.Marquee;
            
            // esperamos a la db
            await Task.Delay(500);
            dataUsuarios.DataSource = clienteDB.GetAll(txtSearch.Text);
            dataUsuarios.Columns["IDCliente"].Visible = false;

            toolStripProgressClientes.Style = ProgressBarStyle.Continuous;
            toolStripProgressClientes.Visible = false;
            lblStatus.Text = "Clientes cargados";

        }


        private void ListCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void ListCustomers_Resize(object sender, EventArgs e)
        {

        }

        private void toolStripNuevoCliente_Click(object sender, EventArgs e)
        {
            ClienteDetails clienteDetails = new ClienteDetails(Modo.CREAR);
            clienteDetails.ShowDialog();
            this.RefreshList();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }

    

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.RefreshList();
        }

        // Doble click en la fila del datagrid para editar el cliente
        private void Fila_DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.GetSelectedClienteID();
            ClienteDetails clienteDetails = new ClienteDetails(Modo.EDITAR, id);
            clienteDetails.ShowDialog();
            this.RefreshList();
        }

        private void toolStripDeleteCliente_Click(object sender, EventArgs e)
        {
            var id = this.GetSelectedClienteID();
            if (id == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            ClienteDB clienteDB = new ClienteDB();
            var row = clienteDB.DeleteCliente(id);
            if (row > 0)
            {
                MessageBox.Show("Cliente eliminado correctamente");
                this.RefreshList();
            }
        }

        #region helpers
        private int GetSelectedClienteID()
        {
            if (dataUsuarios.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dataUsuarios.SelectedRows[0].Cells["IDCliente"].Value);
        }

        #endregion

        
    }
}
