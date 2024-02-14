using Facturacion.DataAccess;

namespace TestSistemaDeFacturacion
{
    [TestClass]
    public class UnitTest1
    {
        string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=facturacion_nisasoft;Integrated Security=True;user Id=sa;Password=12345678;";

        [TestMethod]
        public void ProbarConexion()
        {
            // Conexion de la base de datos
            var db = new ConexionBD(this.ConnectionString); 
                                           
            var result = db.ProbarConexion();
            // Assert
            Assert.IsTrue(result);
        }

    }
}