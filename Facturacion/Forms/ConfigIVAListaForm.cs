using Facturacion.DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.Forms
{
    public partial class ConfigIVAListaForm : Form
    {
        public ConfigIVAListaForm()
        {
            InitializeComponent();
        }

        private void ConfigIVAListaForm_Load(object sender, EventArgs e)
        {
            CargarData();
            
        }

        // Recuperamos toda la configuración de IVA de la base de datos.
        private void CargarData() 
        {
            ConfigIVARespositorio configIVARespositorio = new ConfigIVARespositorio();
            dgvConfigIVA.DataSource = configIVARespositorio.ObtenerConfigIVA();
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarData();
        }

        private int ObtenerIDConfigIVASeleccionado()
        {
            if (dgvConfigIVA.SelectedRows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dgvConfigIVA.SelectedRows[0].Cells["ID_IVA"].Value);
        }

        private void btnEliminarIVA_Click(object sender, EventArgs e)
        {
            var id = ObtenerIDConfigIVASeleccionado();
            if (id == 0)
            {
                MessageBox.Show("Seleccione una regla de IVA para eliminarlo.");
                return;
            }
            
            ConfigIVARespositorio configIVARespositorio = new ConfigIVARespositorio();
            try {
                var ok = configIVARespositorio.EliminarConfigIVA(id);
                if (ok)
                {
                    MessageBox.Show($"Se elimino la configuración del IVA con ID: {id}");
                    CargarData();
                }
            } catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("No se pudo eliminar la configuración del IVA.");
            }
            
           
        }

        private void bntNuevoIVA_Click(object sender, EventArgs e)
        {
            ConfigIVANuevoEdit configIVANuevoEdit = new ConfigIVANuevoEdit();
            configIVANuevoEdit.ShowDialog();
            CargarData();
        }

        private void dgvConfigIVA_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // el registro seleccionado se enviara para editar.
            var id = ObtenerIDConfigIVASeleccionado();
            if (id == 0)
            { 
                MessageBox.Show("Seleccione una regla de IVA para editarla.");
            }

            ConfigIVANuevoEdit configIVANuevoEdit = new ConfigIVANuevoEdit(id);
            configIVANuevoEdit.ShowDialog();
            CargarData();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConfigIVASimuladorForm simulador = new ConfigIVASimuladorForm();
            simulador.ShowDialog();
        }
    }
}
