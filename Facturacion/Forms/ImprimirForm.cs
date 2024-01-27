using Facturacion.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class ImprimirForm : Form
    {
        Factura factura;
        public ImprimirForm(Factura factura)
        {
            InitializeComponent();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Facturacion.FacturaReporte.rdlc";
            this.factura = factura;
        }

        private void ImprimirForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSetFactura", new List<Factura> { factura });
            ReportDataSource cliente = new ReportDataSource("DataSetCliente", new List<Cliente> { factura.Cliente });
            ReportDataSource detalles = new ReportDataSource("DataSetDetalles", factura.Detalles );
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(cliente);
            reportViewer1.LocalReport.DataSources.Add(detalles);
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Facturacion.FacturaReporte.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
