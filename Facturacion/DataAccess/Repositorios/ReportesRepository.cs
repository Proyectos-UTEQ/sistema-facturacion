using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.DataAccess.Repositorios
{
    public class ReportesRepository : ConexionBD
    {

        public ReportesRepository() { }

        public DataTable ObtenerResumenDeVenta() 
        {
            string query = $@"SELECT
                                F.FECHA_HORA AS fecha_venta,
                                C.NOMBRES AS nombre_cliente,
                                P.NOMBRE AS nombre_producto,
                                FD.CANTIDAD AS cantidad_vendida,
                                FD.PRECIO_UNITARIO AS precio_unitario,
                                FD.CANTIDAD * FD.PRECIO_UNITARIO AS total_venta
                            FROM
                                FACTURA F
                                INNER JOIN CLIENTE C ON F.ID_CLIENTE = C.ID_CLIENTE
                                INNER JOIN FACTURAS_DETALLES FD ON F.ID_FACTURA = FD.ID_FACTURA
                                INNER JOIN PRODUCTO P ON FD.ID_PRODUCTO = P.ID_PRODUCTO";

            DataTable data = EjecutarConsulta(query, null);
            return data;
        }

        public DataTable ObtenerReporteDeFactura() 
        {
            string query = $@"SELECT
                                F.ID_FACTURA,
                                F.FECHA_HORA,
                                C.NOMBRES AS nombre_cliente,
                                P.NOMBRE AS nombre_producto,
                                FD.CANTIDAD AS cantidad_vendida,
                                FD.PRECIO_UNITARIO AS precio_unitario,
                                FD.CANTIDAD * FD.PRECIO_UNITARIO AS total_venta
                            FROM
                                FACTURA F
                                INNER JOIN CLIENTE C ON F.ID_CLIENTE = C.ID_CLIENTE
                                INNER JOIN FACTURAS_DETALLES FD ON F.ID_FACTURA = FD.ID_FACTURA
                                INNER JOIN PRODUCTO P ON FD.ID_PRODUCTO = P.ID_PRODUCTO";

            DataTable data = EjecutarConsulta(query, null);
            return data;
        }
    }
}
