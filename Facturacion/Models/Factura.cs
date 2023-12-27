using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Models
{
    // Modelo de datos para las facturas
    public class Factura
    {
        public int IDFactura { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Numero { get; set; }
        public decimal Total { get; set; }
    }
}
