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
    public partial class InformeDeFactura : Form
    {
        public InformeDeFactura()
        {
            InitializeComponent();
        }

        private void InformeDeFactura_Load(object sender, EventArgs e)
        {
            ReportesRepository reportesRepository = new ReportesRepository();
            dataInformeFactura.DataSource = reportesRepository.ObtenerReporteDeFactura();
        }
    }
}
