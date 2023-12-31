﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.DataAccess
{
    public class DbContext
    {

        public string connectionString = string.Empty;

        public DbContext() {

            // Obtener la cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }
    }
}
