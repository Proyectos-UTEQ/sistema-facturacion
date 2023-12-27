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
    public partial class Main : Form
    {

        // variables globales para las ventanas.
        ClienteListaForm listcustomer;
        ProductoListaForm listadoProductos;
        FacturaLIstaForm listFactura;

        public Main()
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

        private async void Main_Load(object sender, EventArgs e)
        {
            // validamos la base de datos
            await Task.Run(async () => await validarConexionAsync());
        }

        // validamos la base de datos y actualizamos el estado de la barra de estado.
        private async Task validarConexionAsync() 
        { 
            // Probar conexion a base de datos, y mostrar mensaje de error en caso de fallo.
            ClienteRepositorio clienteDB = new ClienteRepositorio();
            var ok = clienteDB.Ok();
            UpdateStatus(await ok);
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
                listFactura = new FacturaLIstaForm();
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
