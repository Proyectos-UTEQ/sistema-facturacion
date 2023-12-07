using Facturacion.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.clientes
{
    public partial class ClienteDetails : Form
    {
        public string modo = "CREAR";

        public ClienteDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClienteDetails_Load(object sender, EventArgs e)
        {
            if (this.modo == "CREAR")
            {
                this.Text = "Crear Cliente";
            }
            else
            {
                this.Text = "Editar Cliente";
            }   
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (this.modo == "CREAR")
            {
                this.CrearCliente();
            }
            else
            {
                this.EditarCliente();
            }
        }

        private void CrearCliente()
        {
            ClienteDB clienteDB = new ClienteDB();

            Cliente cliente = new Cliente();
            cliente.Cedula = txtCedula.Text;
            cliente.Nombres = txtNombres.Text;
            cliente.Apellidos = txtApellidos.Text;
            cliente.Telefonos = txtTelefono.Text;
            cliente.IDCliente = clienteDB.AddUser(cliente);

            // actualizamos el id del cliente en el formulario
            txtIDCliente.Text = cliente.IDCliente.ToString();
            this.updateTitle();
            this.modo = "EDITAR";
        }

        private void EditarCliente()
        {
            ClienteDB clienteDB = new ClienteDB();

            Cliente cliente = new Cliente();
            cliente.IDCliente = Convert.ToInt32(txtIDCliente.Text);
            cliente.Cedula = txtCedula.Text;
            cliente.Nombres = txtNombres.Text;
            cliente.Apellidos = txtApellidos.Text;
            cliente.Telefonos = txtTelefono.Text;
            var rowAffect = clienteDB.UpdateUser(cliente);
            if (rowAffect > 0)
            {
                MessageBox.Show("Cliente actualizado correctamente");
                this.updateTitle();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el cliente");
            }   
        }

        private void updateTitle()
        {
            this.Text = "Cliente: " + txtNombres.Text;
        }
    }
}
