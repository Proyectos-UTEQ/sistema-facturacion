using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.DTOs
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public int IDCliente { get; set; }
        public string Cedula { get; set; }
        public string Cliente { get; set; }
        public string Telefonos { get; set; }

    }
}
