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
        private Modo Modo;

        public event EventHandler<int> OnClienteSelecionado;

        public ClienteListaForm(Modo modo = Modo.NORMAL)
        {
            InitializeComponent();

            this.Modo = modo;
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
            // this.RefreshList();
            if (this.Modo == Modo.SELECIONAR)
            {
                this.toolStripNuevoCliente.Visible = true;
                this.toolStripDeleteCliente.Visible = false;
            }

            toolStrip1.Focus();
            CampoSelecionado.SelectedIndex = 2;
        }

        private void RecargarClientes()
        {
            // En caso de estar basico el campo para buscar.
            //if (txtSearch.Text.Length == 0)
            //{
            //    return;
            //}

            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            lblStatus.Text = "Cargando clientes...";
            // configuramos el progresbar
            toolStripProgressClientes.Visible = true;
            toolStripProgressClientes.Style = ProgressBarStyle.Marquee;
            
            dataUsuarios.DataSource = clienteRepositorio.ObtenerClientes(txtSearch.Text, CampoSelecionado.Text);
            //dataUsuarios.Columns["IDCliente"].Visible = false;

            toolStripProgressClientes.Style = ProgressBarStyle.Continuous;
            toolStripProgressClientes.Visible = false;
            lblStatus.Text = "Clientes cargados";

        }


        private void ToolStripNuevoCliente_Click(object sender, EventArgs e)
        {
            ClienteDetallesForm clienteDetails = new ClienteDetallesForm(Modo.CREAR);
            clienteDetails.ShowDialog();
        }

        private void BtnUpdateList_Click(object sender, EventArgs e)
        {
            this.RecargarClientes();
        }

        // Doble click en la fila del datagrid para editar el cliente
        private void Fila_DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.GetSelectedClienteID();
            ClienteDetallesForm clienteDetails = new ClienteDetallesForm(Modo.EDITAR, id);
            clienteDetails.ShowDialog();
            this.RecargarClientes();
        }

        private void ToolStripDeleteCliente_Click(object sender, EventArgs e)
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
                this.RecargarClientes();
            }
        }

        private int GetSelectedClienteID()
        {
            if (dataUsuarios.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dataUsuarios.SelectedRows[0].Cells["ID_CLIENTE"].Value);
        }

 

        // boton para seleccionar un cliente.
        private void BtnSeleccionar_Click(object sender, EventArgs e)
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.RecargarClientes();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                RecargarClientes();
                e.Handled = true;
            }
        }

        private void dataUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // en caso de que no sea de selecionar.
            if (Modo != Modo.SELECIONAR)
            {
                return;
            }

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
