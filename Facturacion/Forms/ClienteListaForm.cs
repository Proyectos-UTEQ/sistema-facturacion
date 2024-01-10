using Facturacion.Helpers;
using Facturacion.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.clientes
{

    public partial class ClienteListaForm : Form
    {
        // modo de utilizacion del formulario.
        private Modo modo;

        public event EventHandler<int> OnClienteSelecionado;

        public ClienteListaForm(Modo modo = Modo.NORMAL)
        {
            InitializeComponent();

            this.modo = modo;
        }

        // Emite el evento.
        private void EnviarCliente(int id)
        {
            if (this.OnClienteSelecionado != null)
            {
                this.OnClienteSelecionado?.Invoke(this, id);
            }
        }

        private void ListCustomers_Load(object sender, EventArgs e)
        {
            this.RefreshList();
            if (this.modo == Modo.SELECIONAR)
            {
                this.btnSeleccionar.Visible = true;
                this.toolStripNuevoCliente.Visible = false;
                this.toolStripDeleteCliente.Visible = false;
            }
            else 
            { 
                this.btnSeleccionar.Visible = false;
            }
            toolStrip1.Focus();
        }

        private void RefreshList()
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            lblStatus.Text = "Cargando clientes...";
            // configuramos el progresbar
            toolStripProgressClientes.Visible = true;
            toolStripProgressClientes.Style = ProgressBarStyle.Marquee;
            
            dataUsuarios.DataSource = clienteRepositorio.ObtenerClientes(txtSearch.Text);
            //dataUsuarios.Columns["IDCliente"].Visible = false;

            toolStripProgressClientes.Style = ProgressBarStyle.Continuous;
            toolStripProgressClientes.Visible = false;
            lblStatus.Text = "Clientes cargados";

        }


        private void toolStripNuevoCliente_Click(object sender, EventArgs e)
        {
            ClienteDetallesForm clienteDetails = new ClienteDetallesForm(Modo.CREAR);
            clienteDetails.ShowDialog();
            this.RefreshList();
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
            ClienteDetallesForm clienteDetails = new ClienteDetallesForm(Modo.EDITAR, id);
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

            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            var row = clienteRepositorio.EliminarCliente(id);
            if (row > 0)
            {
                MessageBox.Show("Cliente eliminado correctamente");
                this.RefreshList();
            }
        }

        private int GetSelectedClienteID()
        {
            if (dataUsuarios.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dataUsuarios.SelectedRows[0].Cells["IDCliente"].Value);
        }

 

        // boton para seleccionar un cliente.
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var id = GetSelectedClienteID();
            if (id == 0)
            {
                MessageBox.Show("Seleccione un cliente");
            }
            else 
            { 
                EnviarCliente(id);
                Close();
            }
        }
    }
}
