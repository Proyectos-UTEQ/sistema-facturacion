using Facturacion.DataAccess.Repositorios;
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.Forms
{
    public partial class ConfigIVASimuladorForm : Form
    {
        private ConfigIVA config = null;
        public ConfigIVASimuladorForm()
        {
            InitializeComponent();
        }

        private void dateIVA_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateIVA.Value;
            ConfigIVARespositorio repositorio = new ConfigIVARespositorio();
            try 
            { 
                config = repositorio.getConfigIVAByDate(selectedDate);
                txtIVAConfig.Text = config.VALOR_IVA.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
                
                // mostramo el formato de porcentaje
                decimal porcentaje = config.VALOR_IVA * 100;
                txtIVAPorcentaje.Text = porcentaje.ToString("#,##0.##") + "%";
                CalcularIVA();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularIVA();
        }

        private void CalcularIVA() 
        {
            if (config == null) return;

            if (decimal.TryParse(txtSubTotal.Text, out decimal subTotal))
            { 
                decimal iva = subTotal * config.VALOR_IVA;
                decimal total = subTotal + iva;
                
                labelIVA.Text = $"{iva.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
                labelTotal.Text = $"{total.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
            }
        }
    }
}
