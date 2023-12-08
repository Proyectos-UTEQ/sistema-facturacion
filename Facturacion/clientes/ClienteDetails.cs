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
    public enum Modo
    {
        CREAR,
        EDITAR
    }
    public partial class ClienteDetails : Form
    {
        private Modo modo = Modo.CREAR;
        private int id = 0;

        public ClienteDetails(Modo modo, int id = 0)
        {
            InitializeComponent();

            // establecemos el modo y el id si es para editar.
            this.modo = modo;
            this.id = id;
        }

        private void loadCliente()
        {
            ClienteDB clienteDB = new ClienteDB();
            Cliente cliente = clienteDB.GetCliente(this.id);
            txtIDCliente.Text = cliente.IDCliente.ToString();
            txtCedula.Text = cliente.Cedula;
            txtNombres.Text = cliente.Nombres;
            txtApellidos.Text = cliente.Apellidos;
            txtTelefono.Text = cliente.Telefonos;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClienteDetails_Load(object sender, EventArgs e)
        {
            if (this.modo == Modo.CREAR)
            {
                this.Text = "Crear Cliente";
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.loadCliente();
                this.updateTitle();
            }   
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (this.modo == Modo.CREAR)
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
            this.modo = Modo.EDITAR;
        }

        private void EditarCliente()
        {
            ClienteDB clienteDB = new ClienteDB();

            Cliente cliente = new Cliente();
            cliente.IDCliente = Convert.ToInt32(txtIDCliente.Text);
            cliente.Cedula = txtCedula.Text.Trim();
            cliente.Nombres = txtNombres.Text.Trim();
            cliente.Apellidos = txtApellidos.Text.Trim();
            cliente.Telefonos = txtTelefono.Text.Trim();
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
            this.Text = $"Cliente <{txtNombres.Text.Trim()}>";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            // si el cliente no ha sido creado, no se puede eliminar
            if (this.modo == Modo.CREAR)
            {
                MessageBox.Show("No se puede eliminar un cliente que no ha sido creado");
                return;
            }

            // confirmar eliminacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // eliminar cliente
            ClienteDB clienteDB = new ClienteDB();
            var rowAffect = clienteDB.DeleteCliente(this.id);
            if (rowAffect > 0)
            {
                MessageBox.Show("Cliente eliminado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el cliente");
            }
        }
    }
}
