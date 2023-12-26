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
using Facturacion.facturas;
using Facturacion.productos;

namespace Facturacion
{
    public partial class Main : Form
    {
        ListClients listcustomer;
        ListadoProductos listadoProductos;
        ListFactura listFactura;

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
            else
            {
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

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listadoProductos != null)
            {
                listadoProductos.Focus();
            }
            else
            {
                listadoProductos = new ListadoProductos();
                listadoProductos.MdiParent = this;
                listadoProductos.FormClosed += listadoProductos_FormClosed;
                listadoProductos.Show();
            }
        }

        private void listadoProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            listadoProductos = null;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        ///  boton de factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listFactura != null)
            {
                listFactura.Focus();
            }
            else
            {
                listFactura = new ListFactura();
                listFactura.MdiParent = this;
                listFactura.FormClosed += listFactura_FormClosed;
                listFactura.Show();
            }
        }

        private void listFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFactura = null;
        }
    }
}
