using System.Data;
using System.Data.SqlClient;
using Facturacion.clientes;
using Facturacion.DataAccess;
using Facturacion.data;
using Facturacion.Models;

namespace TestSistemaDeFacturacion
{
    [TestClass]
    public class UnitTestFacturas
    { 
        FacturaRepositorio repo = new FacturaRepositorio();
 
          
        [TestMethod]
        public void TestObtenerFacturasPorIdFactura()
        {
            repo = new FacturaRepositorio();
            var palabra = "6";
            var campo = "ID_FACTURA";
            DataTable resultado = repo.ObtenerFacturas(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count > 1);  
        }
        [TestMethod]
        public void TestObtenerFacturasPorNumero()
        {
            repo = new FacturaRepositorio();
            var palabra = "1";
            var campo = "NUMERO";
            DataTable resultado = repo.ObtenerFacturas(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count > 1);  

        }

        [TestMethod]
        public void TestObtenerFacturasPorCliente()
        {
            repo = new FacturaRepositorio();
            var palabra = "Karla";
            var campo = "CLIENTE";
            DataTable resultado = repo.ObtenerFacturas(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count > 1);  

        }

        [TestMethod]
        public void TestObtenerFacturasPorTotal()
        {
            repo = new FacturaRepositorio();
            var palabra = "1";
            var campo = "TOTAL";
            DataTable resultado = repo.ObtenerFacturas(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count > 1);  

        }

        // CREAR
        [TestMethod]
        public void TestRegistrarFacturas()
        {
            repo = new FacturaRepositorio();


            var cliente = new Cliente
            {
                IDCliente = 1 
            };

            var factura = new Factura
            {
                IDCliente = cliente.IDCliente,
                Cliente = cliente,
                FechaHora = DateTime.Now,
                Numero = 15,  
                Total = 100.00m,  
                Estado = 1   
            };

            var idFactura = repo.RegistrarNuevaFactura(factura);

        
            Assert.IsTrue(idFactura > 0);
        }

        // ACTUALIZAR
        [TestMethod]
        public void TestActualizarFacturas()
        {
            repo = new FacturaRepositorio();


            var cliente = new Cliente
            {
                IDCliente = 1
            };

            var factura = new Factura
            {
                IDFactura = 1,
                IDCliente = cliente.IDCliente,
                Cliente = cliente,
                FechaHora = DateTime.Now,
                Numero = 15,
                Total = 100.00m,
                Estado = 1
            };

            var filasAfectadas = repo.UpdateFactura(factura);

            
            Assert.AreEqual(1, filasAfectadas);
        }

        // ELIMINAR
        [TestMethod]
        public void TestEliminarFacturas()
        {
            repo = new FacturaRepositorio();

            var idFactura = 20014;

            var resultado = repo.DeleteFactura(idFactura);

            Assert.IsNotNull(resultado);
        }
    }
}