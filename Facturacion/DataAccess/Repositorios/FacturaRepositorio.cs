using Facturacion.DataAccess;
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Facturacion.data
{
    

    public class FacturaRepositorio : DbContext
    {
        
        public FacturaRepositorio()
        {
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

        // Recupera todas las facturas con los datos del cliente.
        public List<Factura> ObtenerFacturas(string search)
        {
            // TODO: Recuperar las facturas con los datos del cliente.

            List<Factura> facturas = new List<Factura>();

            string query = @"
                            SELECT f.ID_FACTURA, f.ID_CLIENTE, f.FECHA_HORA, f.NUMERO, f.TOTAL, f.ESTADO, c.ID_CLIENTE, c.CEDULA, c.NOMBRES, c.APELLIDOS, c.TELEFONO, c.ESTADO
                            FROM FACTURA as f
                            INNER JOIN CLIENTE as c ON f.ID_CLIENTE=c.ID_CLIENTE
                            where (f.ID_FACTURA like @SEARCH or f.ID_CLIENTE like @SEARCH 
	                        or f.FECHA_HORA like @SEARCH or f.NUMERO like @SEARCH) and f.ESTADO = 1
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
                        // creamos la instancia de factura.
                        Factura factura = new Factura { 
                            IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString()),
                            IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString()),
                            FechaHora = Convert.ToDateTime(reader["FECHA_HORA"]),
                            Numero = (int)Convert.ToInt64(reader["NUMERO"].ToString()),
                            Total = Convert.ToDecimal(reader["TOTAL"]),
                            Estado = Convert.ToInt32(reader["ESTADO"]),

                            // Instaciamos el cliente.
                            Cliente = new Cliente { 
                                IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString()),
                                Cedula = reader["CEDULA"].ToString(),
                                Nombres = reader["NOMBRES"].ToString(),
                                Apellidos = reader["APELLIDOS"].ToString(),
                                Telefonos = reader["TELEFONO"].ToString(),
                            },
                        };

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

            // Query para recuperar la cabecera de la factura.
            string queryFacturaCabezera = @"SELECT ID_FACTURA, ID_CLIENTE, FECHA_HORA, NUMERO, TOTAL  
                                from FACTURA
                                where ID_FACTURA = @ID_FACTURA
                            ";

            // Query para recuperar el detalle de la factura.
            string queryFacturaDetalle = @"SELECT ID_FACTURA_DETALLE, ID_FACTURA, ID_PRODUCTO, DESCRIPCION, CANTIDAD, PRECIO_UNITARIO, SUB_TOTAL
                                from FACTURAS_DETALLES
                                where ID_FACTURA = @ID_FACTURA
                            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmdCabezera = new SqlCommand(queryFacturaCabezera, conn);
                cmdCabezera.Parameters.AddWithValue("@ID_FACTURA", id);

                SqlCommand cmdDetalle = new SqlCommand(queryFacturaDetalle, conn);
                cmdDetalle.Parameters.AddWithValue("@ID_FACTURA", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmdCabezera.ExecuteReader();
                    if (reader.Read())
                    {
                        factura.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        factura.IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                        factura.FechaHora = Convert.ToDateTime(reader["FECHA_HORA"]);
                        factura.Numero = Convert.ToInt32(reader["NUMERO"]);
                        factura.Total = Convert.ToDecimal(reader["TOTAL"].ToString());
                    }
                    reader.Close();
                    

                    // Recuperamos todos los datos de los detalles de la factura.
                    SqlDataReader readerDetalle = cmdDetalle.ExecuteReader();
                    while (readerDetalle.Read())
                    {
                        // Instanciamos el detalle.
                        FacturaDetalles facturasDetalles = new FacturaDetalles { 
                            IDFacturaDetalle = Convert.ToInt32(readerDetalle["ID_FACTURA_DETALLE"].ToString()),
                            IDFactura = Convert.ToInt32(readerDetalle["ID_FACTURA"].ToString()),
                            IDProducto = Convert.ToInt32(readerDetalle["ID_PRODUCTO"].ToString()),
                            Descripcion = readerDetalle["DESCRIPCION"].ToString(),
                            Cantidad = Convert.ToDecimal(readerDetalle["CANTIDAD"]),
                            PrecioUnitario = Convert.ToDecimal(readerDetalle["PRECIO_UNITARIO"]),
                            SubTotal = Convert.ToDecimal(readerDetalle["SUB_TOTAL"]),
                        };

                        // agregamos el detalle.
                        factura.Detalles.Add(facturasDetalles);
                    }
                    readerDetalle.Close();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return factura;
        }

        public int RegistrarNuevaFactura(Factura factura)
        {

            // TODO: Registrar la factura y recuperamos el id.

            string query = "INSERT INTO FACTURA(ID_CLIENTE, FECHA_HORA, NUMERO, TOTAL, ESTADO) " +
                "OUTPUT Inserted.ID_FACTURA values(@ID_CLIENTE, @FECHA_HORA, @NUMERO, @TOTAL, '1')";

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
                    int idFactura = 0;
                    conn.Open();
                    // Ejecutar comando.
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Obtener ID del cliente.
                        idFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                    conn.Close();
                    return idFactura;
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
            string query = "UPDATE FACTURA SET ID_CLIENTE=@ID_CLIENTE, FECHA_HORA = @FECHA_HORA, NUMERO = @NUMERO, TOTAL = @TOTAL " +
                "WHERE ID_FACTURA=@ID_FACTURA";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", factura.IDCliente);
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

        // Genera un nuevo numero de factura.
        public int NuevoNueroFactura() 
        {

            string query = "SELECT TOP 1 MAX(f.NUMERO) + 1 as nueva_factura FROM FACTURA as f;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    int nuevaFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return nuevaFactura;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    } 
}
