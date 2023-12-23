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
        private bool isModified = false;

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
            txtCedula.Text = cliente.Cedula.Trim();
            txtNombres.Text = cliente.Nombres.Trim();
            txtApellidos.Text = cliente.Apellidos.Trim();
            txtTelefono.Text = cliente.Telefonos.Trim();
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
            this.UpdateStateForms(false);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (!this.ValidateForm())
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

            this.UpdateStateForms(false);
            this.Close();
        }

        private void CrearCliente()
        {
            ClienteDB clienteDB = new ClienteDB();

            Cliente cliente = new Cliente();
            cliente.Cedula = txtCedula.Text.Trim();
            cliente.Nombres = txtNombres.Text.Trim();
            cliente.Apellidos = txtApellidos.Text.Trim();
            cliente.Telefonos = txtTelefono.Text.Trim();
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

            this.UpdateStateForms(true);
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

            this.UpdateStateForms(true);
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

            this.UpdateStateForms(true);
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

            this.UpdateStateForms(true);
        }

        private void UpdateStateForms(bool isModified)
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
            if (this.ValidateForm())
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

        private bool ValidateForm()
        {
            bool cedula = txtCedula.Tag != null ? (bool)txtCedula.Tag : false;
            bool nombres = txtNombres.Tag != null ? (bool)txtNombres.Tag : false;
            bool apellidos = txtApellidos.Tag != null ? (bool)txtApellidos.Tag : false;
            bool telefono = txtTelefono.Tag != null ? (bool)txtTelefono.Tag : false;

            return cedula && nombres && apellidos && telefono;
        }

    }
}
