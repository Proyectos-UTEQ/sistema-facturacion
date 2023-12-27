using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Models
{
    public class DetalleFacturas
    {
        public int IDFacturaDetalle { get; set; }
        public int IDFactura { get; set; }
        public int IDProducto { get; set; }
        public decimal Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
