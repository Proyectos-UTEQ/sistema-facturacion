using Facturacion.DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.Forms
{
    public partial class ResumenVentas : Form
    {
        public ResumenVentas()
        {
            InitializeComponent();
        }

        private void ResumenVentas_Load(object sender, EventArgs e)
        {
            ReportesRepository reportes = new ReportesRepository();
            dataResumenVenta.DataSource = reportes.ObtenerResumenDeVenta();
        }
    }
}
