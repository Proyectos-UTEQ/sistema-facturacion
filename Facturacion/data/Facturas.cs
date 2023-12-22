using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.data
{
    public class Factura
    {
        public int IDFactura { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Numero { get; set; }
        public decimal Total { get; set; }
    }

    public class FacturaDB
    {
        private string connectionString = string.Empty;

        public FacturaDB()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        // Probar conexión.
        public bool Ok()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Factura> GetAll(string search)
        {
            List<Factura> facturas = new List<Factura>();

            string query = @"SELECT ID_FACTURA, ID_CLIENTE, FECHA_HORA, NUMERO, TOTAL 
                                from FACTURA
                                where (ID_FACTURA like @SEARCH or ID_CLIENTE like @SEARCH 
                                or FECHA_HORA like @SEARCH or NUMERO like @SEARCH) and ESTADO = 1
                                order by FECHA_HORA asc
                            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SEARCH", "%" + search + "%");
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Factura factura = new Factura();
                        factura.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        factura.IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                        factura.FechaHora = Convert.ToDateTime(reader["FECHA_HORA"]);
                        factura.Numero = Convert.ToDecimal(reader["NUMERO"]);
                        factura.Total = Convert.ToDecimal(reader["TOTAL"]);

                        facturas.Add(factura);

                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return facturas;
        }

        public Factura GetFactura(int id)
        {
            Factura factura = new Factura();

            string query = @"SELECT ID_FACTURA, ID_CLIENTE, FECHA_HORA, NUMERO, TOTAL  
                                from FACTURA
                                where ID_FACTURA = @ID_FACTURA
                            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", id);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        factura.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        factura.IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                        factura.FechaHora = Convert.ToDateTime(reader["FECHA_HORA"]);
                        factura.Numero = Convert.ToDecimal(reader["NUMERO"]);
                        factura.Total = Convert.ToDecimal(reader["TOTAL"].ToString());
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return factura;
        }

        public int AddFactura(Factura factura)
        {

            string query = "insert into FACTURA(ID_CLIENTE, FECHA_HORA, NUMERO,TOTAL, ESTADO) " +
                "OUTPUT Inserted.ID_CLIENTE values(@ID_CLIENTE, @FECHA_HORA, @NUMERO, @TOTAL, '1')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Crear comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", factura.IDCliente);
                cmd.Parameters.AddWithValue("@FECHA_HORA", factura.FechaHora);
                cmd.Parameters.AddWithValue("@NUMERO", factura.Numero);
                cmd.Parameters.AddWithValue("@TOTAL", factura.Total);

                try
                {
                    conn.Open();
                    // Ejecutar comando.
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Obtener ID del cliente.
                        return Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int GetIDFinal()
        {
            string query = "SELECT ISNULL(MAX(ID_FACTURA), 0) FROM FACTURA";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public int UpdateFactura(Factura factura)
        {
            string query = "UPDATE FACTURA SET FECHA_HORA = @FECHA_HORA, NUMERO = @NUMERO, TOTAL = @TOTAL " +
                "WHERE ID_FACTURA=@ID_FACTURA";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", factura.IDFactura);
                cmd.Parameters.AddWithValue("@FECHA_HORA", factura.FechaHora);
                cmd.Parameters.AddWithValue("@NUMERO", factura.Numero);
                cmd.Parameters.AddWithValue("@TOTAL", factura.Total);
               
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int DeleteFactura(int id)
        {
            string query = "UPDATE FACTURA SET ESTADO = 0 WHERE ID_FACTURA=@ID_FACTURA";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", id);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    } 
}
