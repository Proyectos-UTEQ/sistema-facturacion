using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Facturacion.DataAccess;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void ProbarConexion()
        {
            // Conexion de la base de datos
            var db = new ConexionBD();

            var result = db.ProbarConexion();
            // Assert
            Assert.IsTrue(result);
        }
    }
}
