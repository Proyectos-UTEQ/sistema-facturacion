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
using Facturacion.DataAccess;
using Facturacion.facturas;
using Facturacion.Forms;
using Facturacion.models;
using Facturacion.productos;

namespace Facturacion
{
    public partial class MainForm : Form
    {

        // variables globales para las ventanas.
        ClienteListaForm listadeClientes;
        ProductoListaForm listadoProductos;
        FacturaListaForm listFactura; 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConexionBD conn = new ConexionBD();
            UpdateStatus(conn.ProbarConexion());
        }

        // eventos del menu principal, boton para abrir lista de clientes.
        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listadeClientes != null)
            {
                listadeClientes.Focus();
            }
            else
            {
                listadeClientes = new ClienteListaForm();
                listadeClientes.MdiParent = this;
                listadeClientes.FormClosed += Listcustomer_FormClosed;
                listadeClientes.Show();
            }
        }

        private void Listcustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            listadeClientes = null;
        }

        // eventos del menu principal, boton para abrir lista de productos.
        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listadoProductos != null)
            {
                listadoProductos.Focus();
            }
            else
            {
                listadoProductos = new ProductoListaForm();
                listadoProductos.MdiParent = this;
                listadoProductos.FormClosed += ListadoProductos_FormClosed;
                listadoProductos.Show();
            }
        }

        private void ListadoProductos_FormClosed(object sender, FormClosedEventArgs e)
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
        private void FacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listFactura != null)
            {
                listFactura.Focus();
            }
            else
            {
                listFactura = new FacturaListaForm();
                listFactura.MdiParent = this;
                listFactura.FormClosed += ListFactura_FormClosed;
                listFactura.Show();
            }
        }

        private void ListFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFactura = null;
        } 
    }
}
