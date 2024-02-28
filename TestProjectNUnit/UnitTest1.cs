using Facturacion.DataAccess;


namespace TestProjectNUnit
{
    public class Tests
    {
        string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=facturacion_nisasoft;Integrated Security=True;user Id=sa;Password=12345678;";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProbarConexion()
        {
            // Conexion de la base de datos
            var db = new ConexionBD(this.ConnectionString);

            var result = db.ProbarConexion();
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestEjecutarComando()
        {
            var db = new ConexionBD(this.ConnectionString);

            var data = db.EjecutarConsulta("SELECT 1", null);
            Assert.IsNotNull(data);

        }
    }
}