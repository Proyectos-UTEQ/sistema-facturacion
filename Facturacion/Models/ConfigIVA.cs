using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Models
{
    public class ConfigIVA
    {
        public int ID_IVA { get; set; }
        public decimal VALOR_IVA { get; set; }
        public DateTime RIGE_DESDE { get; set; }
        public bool ELIMINADO { get; set; }
    }
}
