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
            this.factura = factura;
        }

        private void ImprimirForm_Load(object sender, EventArgs e)
        {
            //Factura factura = new Factura { 
            //    IDFactura = 1,
            //    IDCliente = 1,
            //    Numero = 1000,
            //    Cliente = new Cliente { 
            //        IDCliente = 1, 
            //        Cedula = "123456789", 
            //        Nombres = "Juan", 
            //        Apellidos = "Perez",
            //        Telefonos = "123456789"
            //    },
            //    FechaHora = DateTime.Now,
            //    Total = 100,
            //    Detalles = new List<FacturaDetalles>() { 
            //        new FacturaDetalles {
            //            IDFactura = 1,
            //            IDProducto = 1,
            //            Cantidad = 320,
            //            PrecioUnitario = 100,
            //            Descripcion = "Laptop",
            //        },
            //        new FacturaDetalles {
            //            IDFactura = 1,
            //            IDProducto = 3,
            //            Cantidad = 320,
            //            PrecioUnitario = 323,
            //            Descripcion = "sdf",
            //        },
            //    },
            //};
            ReportDataSource rds = new ReportDataSource("DataSetFactura", new List<Factura> { factura });
            ReportDataSource cliente = new ReportDataSource("DataSetCliente", new List<Cliente> { factura.Cliente });
            ReportDataSource detalles = new ReportDataSource("DataSetDetalles", factura.Detalles );
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(cliente);
            reportViewer1.LocalReport.DataSources.Add(detalles);
            reportViewer1.LocalReport.ReportEmbeddedResource = "Facturacion.FacturaReporte.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
