using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Facturacion.Models;

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

        public int NUMERO_FACTURA { get; set; }
        
        public bool ESTADO { get; set; }

        public decimal CONFIG_IVA { get; set; }

        public decimal SUB_TOTAL { get; set; }

        public decimal IVA { get; set; }

        public decimal TOTAL_CON_IVA { get; set; }

        public int ID_CONFIG_IVA { get; set; }


        public List<FacturaDetalles> Detalles { get; set; } = new List<FacturaDetalles>();
    }
}
