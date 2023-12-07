using Facturacion.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void RefreshList()
        {
            ClienteDB clienteDB = new ClienteDB();
            dataUsuarios.DataSource = clienteDB.GetAll();
        }

        private void ListCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void ListCustomers_Resize(object sender, EventArgs e)
        {

        }

        private void toolStripNuevoCliente_Click(object sender, EventArgs e)
        {
            ClienteDetails clienteDetails = new ClienteDetails();
            clienteDetails.ShowDialog();
            this.RefreshList();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }
    }
}
