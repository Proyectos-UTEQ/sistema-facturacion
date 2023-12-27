using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Facturacion.Models
{
    // Modelo de datos para las facturas
    public class Factura
    {
        public int IDFactura { get; set; }

        // Referencia hacia el cliente.
        public int IDCliente { get; set; }

        public Cliente Cliente { get; set; } = new Cliente();

        public DateTime FechaHora { get; set; }

        public int Numero { get; set; }

        public decimal Total { get; set; }

        public int Estado { get; set; }
    }
}
