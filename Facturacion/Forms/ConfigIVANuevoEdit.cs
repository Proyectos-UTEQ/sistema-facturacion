using Facturacion.DataAccess.Repositorios;
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.Forms
{
    public partial class ConfigIVANuevoEdit : Form
    {

        private int id = 0;

        public ConfigIVANuevoEdit()
        {
            InitializeComponent();
        }

        public ConfigIVANuevoEdit(int id) 
        {
            InitializeComponent();
            this.id = id;
            CargarDatos();
        }

        private void CargarDatos() 
        { 
            ConfigIVARespositorio configIVARespositorio = new ConfigIVARespositorio();
            var configIVA = configIVARespositorio.ConfigIVA(id);

            // Cargamos los datos en el formulario.
            txtIDIVA.Text = configIVA.ID_IVA.ToString();
            txtValorIVA.Text = configIVA.VALOR_IVA.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
            // dateRigedesde.MinDate = configIVA.RIGE_DESDE;
            if (configIVA.RIGE_DESDE <= DateTime.Now)
            {
                dateRigedesde.MinDate = configIVA.RIGE_DESDE;
            }
            else { 
                dateRigedesde.MinDate = DateTime.Now;
            }
            dateRigedesde.Value = configIVA.RIGE_DESDE;

        }

        private void ConfigIVANuevoEdit_Load(object sender, EventArgs e)
        {
            if (id != 0) return;

            dateRigedesde.MinDate = DateTime.Now;
            dateRigedesde.Value = DateTime.Now;
            txtValorIVA.Text = "0,12";
        }


        private void txtValorIVA_TextChanged(object sender, EventArgs e)
        {

            if (decimal.TryParse(txtValorIVA.Text, out decimal valorIVA))
            {
                decimal porcentaje = valorIVA * 100;
                txtPorcentajeIVA.Text = porcentaje.ToString("#,##0.##") + "%";
            }
            else {
                txtPorcentajeIVA.Clear();
            }
        }

        private void txtValorIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, el coma y la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // Permitir solo un coma decimal
            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            ConfigIVARespositorio configIVARespositorio = new ConfigIVARespositorio();
            if (id == 0)
            {
                try
                {
                    decimal iva = decimal.Parse(txtValorIVA.Text);
                    configIVARespositorio.NuevoConfigIVA(iva, dateRigedesde.Value);
                    MessageBox.Show("Se registro la configuración del IVA");
                    Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        MessageBox.Show("Ya existe una configuración del IVA para esa fecha");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar la configuración del IVA");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("El valor del IVA debe ser un número por ejemplo 0,12");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {

                try
                {
                    decimal iva = decimal.Parse(txtValorIVA.Text);
                    ConfigIVA configUpdated = new ConfigIVA()
                    {
                        ID_IVA = id,
                        VALOR_IVA = iva,
                        RIGE_DESDE = dateRigedesde.Value
                    };

                    configIVARespositorio.UpdateConfigIVA(configUpdated);
                    MessageBox.Show("Se actualizo la configuración del IVA");
                    Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        MessageBox.Show("Ya existe una configuración del IVA para esa fecha");
                    }
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
