using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Models
{
    // Modelo de datos de DetalleFacturas.
    public class FacturaDetalles
    {
        public int IDFacturaDetalle { get; set; }
        public int IDFactura { get; set; }
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
