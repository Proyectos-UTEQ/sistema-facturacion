using System.Data; 
using Facturacion.DataAccess;
using Facturacion.models;
using Facturacion.Models;

namespace TestSistemaDeFacturacion
{
    [TestClass]
    public class UnitTestClientes
    {
        string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=facturacion_nisasoft;Integrated Security=True;user Id=sa;Password=12345678;";
        ClienteRepositorio repo = new ClienteRepositorio();

        [TestMethod]
        public void ProbarConexion()
        {
            // Conexion de la base de datos
            var db = new ConexionBD(this.ConnectionString); 
                                           
            var result = db.ProbarConexion();
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEjecutarComando()
        { 
            var db = new ConexionBD(this.ConnectionString);

            var data = db.EjecutarConsulta("SELECT 1", null);
            Assert.IsNotNull(data);

        }
         

        [TestMethod]
        public void TestObtenerClientesPorIdCliente()
        {
            repo = new ClienteRepositorio();
            var palabra = "1";
            var campo = "ID_CLIENTE";
            DataTable resultado = repo.ObtenerClientes(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count > 1); 
        }
        [TestMethod]
        public void TestObtenerClientesPorCedula()
        {
            repo = new ClienteRepositorio();
            var palabra = "1202342323";
            var campo = "CEDULA";
            DataTable resultado = repo.ObtenerClientes(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count == 1); 

        }

        [TestMethod]
        public void TestObtenerClientesPorNombres()
        {
            repo = new ClienteRepositorio();
            var palabra = "Karla";
            var campo = "NOMBRES";
            DataTable resultado = repo.ObtenerClientes(palabra, campo);
            Assert.IsNotNull(resultado);
            

        }

        [TestMethod]
        public void TestObtenerClientesPorApellidos()
        {
            repo = new ClienteRepositorio();
            var palabra = "Almea";
            var campo = "APELLIDOS";
            DataTable resultado = repo.ObtenerClientes(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count > 1);  

        }

        [TestMethod]
        public void TestObtenerClientesPorTelefono()
        {
            repo = new ClienteRepositorio();
            var palabra = "0999838238";
            var campo = "TELEFONO";
            DataTable resultado = repo.ObtenerClientes(palabra, campo);

            Assert.IsTrue(resultado.Rows.Count == 1);  
        }


        // CREAR
        [TestMethod]
        public void TestCrearClientes()
        {
            repo = new ClienteRepositorio();
             
            var cliente = new Cliente
            {
                Cedula = "123456789",
                Nombres = "Juan Perez",
                Apellidos = "Lopez",
                Telefonos = "123456789"
            };

            var idCliente = repo.AgregarCliente(cliente);
 
            Assert.IsTrue(idCliente > 0);
        }

        // ACTUALIZAR
        [TestMethod]
        public void TestActualizarClientes()
        {
            repo = new ClienteRepositorio();

        
            var cliente = new Cliente
            {
                IDCliente = 20013,
                Cedula = "123456789",
                Nombres = "Juan Alex",
                Apellidos = "Suarez",
                Telefonos = "123456789"
            };

            var filasAfectadas = repo.ActualizarCliente(cliente);

            // Assert: Validar que se devuelve el número de filas afectadas
            Assert.AreEqual(1, filasAfectadas);
        }

        // ELIMINAR
        [TestMethod]
        public void TestEliminarClientes()
        {
            repo = new ClienteRepositorio();
             
            var idCliente = 20014;

            var filasAfectadas = repo.EliminarCliente(idCliente);

            // Assert: Validar que se devuelve el número de filas afectadas
            Assert.AreEqual(1, filasAfectadas);
        }
    }
}