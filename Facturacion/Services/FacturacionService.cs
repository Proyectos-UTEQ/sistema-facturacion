using Facturacion.data;
using Facturacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Services
{
    // TODO: Implementar Servicio de Facturación
    public class FacturacionService
    {

        public FacturacionService() { }

        public List<FacturaDTO> ObtenerFacturas(string search)
        {
            // lista de facturas a representar
            List<FacturaDTO> facturasDTO = new List<FacturaDTO>();

            FacturaRepositorio repositorio = new FacturaRepositorio();
            var facturas = repositorio.ObtenerFacturas(search);
            facturas.ForEach(factura =>
            {
                facturasDTO.Add(new FacturaDTO
                {
                    Id = factura.IDFactura,
                    Numero = factura.Numero,
                    Fecha = factura.FechaHora,
                    Total = factura.Total,
                    Estado = factura.Estado == 1 ? "Habilitada" : "Borrada",
                    IDCliente = factura.IDCliente,
                    Cedula = factura.Cliente.Cedula.Trim(),
                    Cliente = factura.Cliente.Nombres.Trim() + " " + factura.Cliente.Apellidos.Trim(),
                    Telefonos = factura.Cliente.Telefonos,
                });
            });

            return facturasDTO;
        }
    }
}
