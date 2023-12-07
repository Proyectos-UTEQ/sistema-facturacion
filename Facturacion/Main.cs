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

namespace Facturacion
{
    public partial class Main : Form
    {
        ListClients listcustomer;

        public Main()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listcustomer != null)
            {
                listcustomer.Focus();
            }
            else {
                listcustomer = new ListClients();
                listcustomer.MdiParent = this;
                listcustomer.FormClosed += Listcustomer_FormClosed;
                listcustomer.Show();
            }
        }

        private void Listcustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            listcustomer = null;
        }
    }
}
