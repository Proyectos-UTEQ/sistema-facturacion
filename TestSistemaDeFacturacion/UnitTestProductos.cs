using System.Data;
using System.Data.SqlClient;
using Facturacion.clientes;
using Facturacion.DataAccess;
using Facturacion.models;
using Facturacion.Models;

namespace TestSistemaDeFacturacion
{
    [TestClass]
    public class UnitTestProductos
    {
        string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=facturacion_nisasoft;Integrated Security=True;user Id=sa;Password=12345678;";
        ProductoRespositorio repo = new ProductoRespositorio();

        [TestMethod]
        public void TestGetProducto()
        {
            Producto resultado = repo.GetProducto(3);

            Assert.IsNotNull(resultado); // Verificar de que el resultado no sea nulo
            Assert.AreEqual(3, resultado.IDProducto); // Verificar que el ID del producto coincida con el esperado

        }


        [TestMethod]
        public void TestObtenerProductoPorIdProducto()
        { 
            var palabra = "1";
            var campo = "ID_PRODUCTO";
            DataTable resultado = repo.ObtenerListaProductos(palabra, campo);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Rows.Count > 0);  
        }

       

        [TestMethod]
        public void TestObtenerProductosPorNombres()
        { 
            var palabra = "Arroz";
            var campo = "NOMBRE";
            DataTable resultado = repo.ObtenerListaProductos(palabra, campo);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Rows.Count > 0);  

        }

        [TestMethod]
        public void TestObtenerProductosPorCosto()
        { 
            var palabra = "3";
            var campo = "COSTO";
            DataTable resultado = repo.ObtenerListaProductos(palabra, campo);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Rows.Count > 0);  

        }

        [TestMethod]
        public void TestObtenerProductosPorPrecio()
        { 
            var palabra = "27";
            var campo = "PRECIO";
            DataTable resultado = repo.ObtenerListaProductos(palabra, campo);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Rows.Count > 0);  
        }


        // CREAR
        [TestMethod]
        public void TestAgregarProducto()
        {  
            var producto = new Producto 
            {  
                Nombre = "PAN INTEGRAL",
                Costo = 4,
                Precio = 5
            };

            var idProducto = repo.AgregarProducto(producto);

            Assert.IsNotNull(idProducto);
            Assert.IsTrue(idProducto > 0);
        }

        // ACTUALIZAR
        [TestMethod]
        public void TestActualizarProductos()
        {  
            var cliente = new Producto
            {
                IDProducto = 1,
                Nombre = "Arroz envejecido",
                Costo = 20,
                Precio = 25
            };

            var filasAfectadas = repo.ActualizarProducto(cliente);

            Assert.IsNotNull(filasAfectadas);
            Assert.AreEqual(1, filasAfectadas);
        }

        // ELIMINAR
        [TestMethod]
        public void TestEliminarProductos()
        {  
            var idCliente = 20015;

            var resultado = repo.EliminarProducto(idCliente);

            Assert.IsNotNull(resultado); 
        }
    }
}