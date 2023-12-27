using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Models
{
    // Modelo de datos para Producto.
    public class Producto
    {
        public int IDProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
    }
}
