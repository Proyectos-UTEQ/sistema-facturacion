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
using Facturacion.models;
using Facturacion.productos;

namespace Facturacion
{
    public partial class MainForm : Form
    {

        // variables globales para las ventanas.
        ClienteListaForm listcustomer;
        ProductoListaForm listadoProductos;
        FacturaListaForm listFactura;

        public MainForm()
        {
            InitializeComponent();
        }

        // eventos del menu principal, boton para abrir lista de clientes.
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listcustomer != null)
            {
                listcustomer.Focus();
            }
            else
            {
                listcustomer = new ClienteListaForm();
                listcustomer.MdiParent = this;
                listcustomer.FormClosed += Listcustomer_FormClosed;
                listcustomer.Show();
            }
        }

        private void Listcustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            listcustomer = null;
        }

        // eventos del menu principal, boton para abrir lista de productos.
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listadoProductos != null)
            {
                listadoProductos.Focus();
            }
            else
            {
                listadoProductos = new ProductoListaForm();
                listadoProductos.MdiParent = this;
                listadoProductos.FormClosed += listadoProductos_FormClosed;
                listadoProductos.Show();
            }
        }

        private void listadoProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            listadoProductos = null;
        }

    


        // actualizamos el estado de la barra de estado.
        private void UpdateStatus(bool ok)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(UpdateStatus), ok);
            }
            else { 
                if (ok)
                {
                    toolStripStatusLabelMain.Text = "Conexión a base de datos exitosa.";
                    toolStripStatusLabelMain.ForeColor = Color.Black;
                    toolStripStatusLabelMain.Image = Properties.Resources.yes;
                }
                else
                {
                    toolStripStatusLabelMain.Text = "No se pudo conectar a la base de datos.";
                    toolStripStatusLabelMain.ForeColor = Color.Red;
                    toolStripStatusLabelMain.Image = Properties.Resources.warning;
                }
            }
        }

        // eventos del menu principal, boton para abrir lista de facturas.
        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listFactura != null)
            {
                listFactura.Focus();
            }
            else
            {
                listFactura = new FacturaListaForm();
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
