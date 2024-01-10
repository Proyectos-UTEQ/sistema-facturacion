﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.DataAccess
{
    public class ConexionBD
    {

        public string connectionString = string.Empty;
        private SqlConnection conn;


        public ConexionBD() {

            // Obtener la cadena de conexión desde el archivo de configuración
            string typeConn = ConfigurationManager.AppSettings["connectionString"].ToString();
            connectionString = ConfigurationManager.ConnectionStrings[typeConn].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        // Metodo para abrir la conexión.
        public void AbrirConexion()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Metodo para cerrar la conexión de la db.
        public void CerrarConexion()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public DataTable EjecutarConsulta(string consulta, SqlParameter[] parametros = null)
        { 
            DataTable dataTable = new DataTable();
            try
            {
                AbrirConexion();
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }

            return dataTable;
        }
    }
}
