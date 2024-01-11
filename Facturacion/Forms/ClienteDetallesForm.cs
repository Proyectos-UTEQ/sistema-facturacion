using Facturacion.Helpers;
using Facturacion.models;
using Facturacion.Models;
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

    public partial class ClienteDetallesForm : Form
    {
        // establecemos el modo y el id si es para editar.
        private Modo modo = Modo.CREAR;
        private int id = 0;
        private bool isModified = false;

        public ClienteDetallesForm(Modo modo, int id = 0)
        {
            InitializeComponent();

            // establecemos el modo y el id si es para editar.
            this.modo = modo;
            this.id = id;

            
        }

        // Carga los datos del cliente
        private void loadCliente()
        {
            ClienteRepositorio clienteDB = new ClienteRepositorio();
            Cliente cliente = clienteDB.ObtenerCliente(this.id);
            txtIDCliente.Text = cliente.IDCliente.ToString();
            txtCedula.Text = cliente.Cedula.Trim();
            txtNombres.Text = cliente.Nombres.Trim();
            txtApellidos.Text = cliente.Apellidos.Trim();
            txtTelefono.Text = cliente.Telefonos.Trim();
        }


        private void ClienteDetails_Load(object sender, EventArgs e)
        {
            // Establecemos el modo de funcionamiento del formulario.            
            if (this.modo == Modo.CREAR)
            {
                this.Text = "Crear Cliente";
            }
            else if (this.modo == Modo.EDITAR)
            {
                this.loadCliente();
                this.ActualizarTitulo();
            }
            this.ActualizarEstadoFormulario(false);
        }


        // boton aplicar del formulario.
        // dependiendo del modo, crea o edita el cliente.
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (!this.ValidarFormulario())
            {
                MessageBox.Show("Formulario invalido");
                return;
            }
            if (this.modo == Modo.CREAR)
            {
                this.CrearCliente();
            }
            else
            {
                this.EditarCliente();
            }

            this.ActualizarEstadoFormulario(false);
            this.Close();
        }

        // Crea un nuevo cliente
        private void CrearCliente()
        {
            ClienteRepositorio clienteDB = new ClienteRepositorio();

            Cliente cliente = new Cliente();
            cliente.Cedula = txtCedula.Text.Trim();
            cliente.Nombres = txtNombres.Text.Trim();
            cliente.Apellidos = txtApellidos.Text.Trim();
            cliente.Telefonos = txtTelefono.Text.Trim();
            cliente.IDCliente = clienteDB.AgregarCliente(cliente);

            // actualizamos el id del cliente en el formulario
            txtIDCliente.Text = cliente.IDCliente.ToString();
            this.ActualizarTitulo();
            this.modo = Modo.EDITAR;
        }


        // Edita el cliente existente.
        private void EditarCliente()
        {
            ClienteRepositorio clienteDB = new ClienteRepositorio();

            Cliente cliente = new Cliente();
            cliente.IDCliente = Convert.ToInt32(txtIDCliente.Text);
            cliente.Cedula = txtCedula.Text.Trim();
            cliente.Nombres = txtNombres.Text.Trim();
            cliente.Apellidos = txtApellidos.Text.Trim();
            cliente.Telefonos = txtTelefono.Text.Trim();
            var rowAffect = clienteDB.ActualizarCliente(cliente);
            if (rowAffect > 0)
            {
                MessageBox.Show("Cliente actualizado correctamente");
                this.ActualizarTitulo();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el cliente");
            }   
        }

        // Actualiza el titulo del formulario.
        private void ActualizarTitulo()
        {
            this.Text = $"Cliente <{txtNombres.Text.Trim()}>";
        }

        // boton cancelar.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // boton remover del formulario, solo esta activo si el usuario existe.
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
            ClienteRepositorio clienteDB = new ClienteRepositorio();
            var rowAffect = clienteDB.EliminarCliente(this.id);
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

        // validaciones.
        private void cedula_changed(object sender, EventArgs e)
        {
            
            if (!helpers.FormsValidatros.IsEmpty(txtCedula.Text))
            {
                txtCedula.Tag = helpers.FormsValidatros.IsCedula(txtCedula, lblCedula);
            }
            else
            { 
                lblCedula.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

        private void nombres_changed(object sender, EventArgs e)
        {
            if (!helpers.FormsValidatros.IsEmpty(txtNombres.Text))
            {
                txtNombres.Tag = helpers.FormsValidatros.IsTextLength(txtNombres, lblNombres, 50, 6);
            }
            else { 
                lblNombres.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

        private void apellidos_changed(object sender, EventArgs e)
        {

            if (!helpers.FormsValidatros.IsEmpty(txtApellidos.Text))
            {
                txtApellidos.Tag = helpers.FormsValidatros.IsTextLength(txtApellidos, lblApellidos, 50);
            }
            else
            {
                lblApellidos.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

        private void telefono_changed(object sender, EventArgs e)
        {
            

            if (!helpers.FormsValidatros.IsEmpty(txtTelefono.Text))
            {
                txtTelefono.Tag = helpers.FormsValidatros.IsNumeroLength(txtTelefono, lblTelefono, 10);
            }
            else
            {
                lblTelefono.ForeColor = System.Drawing.Color.Black;
            }

            this.ActualizarEstadoFormulario(true);
        }

        // Actualizar estado del formulario.
        private void ActualizarEstadoFormulario(bool isModified)
        { 
            // controlar el estado de los botones
            if (this.modo == Modo.CREAR)
            {
                this.btnRemover.Enabled = false;
            }
            else
            {
                this.btnRemover.Enabled = true;
            }

            // controlar el estado del boton aplicar
            if (this.ValidarFormulario())
            {
                this.btnAplicar.Enabled = true;
            }
            else
            {
                this.btnAplicar.Enabled = false;
            }
            this.isModified = isModified;
            this.lblStatusEdit.Text = this.isModified ? "Modificado" : "Sin Modificar";
        }

        // Validar formulario
        private bool ValidarFormulario()
        {
            bool cedula = txtCedula.Tag != null ? (bool)txtCedula.Tag : false;
            bool nombres = txtNombres.Tag != null ? (bool)txtNombres.Tag : false;
            bool apellidos = txtApellidos.Tag != null ? (bool)txtApellidos.Tag : false;
            bool telefono = txtTelefono.Tag != null ? (bool)txtTelefono.Tag : false;

            return cedula && nombres && apellidos && telefono;
        }

    }
}
