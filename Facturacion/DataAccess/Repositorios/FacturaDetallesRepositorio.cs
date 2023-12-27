using Facturacion.DataAccess;
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.data
{
    

    // SE USAR PARA IDENTIFICAR EL DETALLE DE LA FACTURA SELECCIONADA
    public class IDS
    {
        public int IDFactura { get; set; }
        public int IDProducto { get; set; }
    }

    public class FacturaDetallesRepositorio : DbContext
    {
       
        public FacturaDetallesRepositorio()
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


        public List<DetalleFacturas> GetAll(string search)
        {
            List<DetalleFacturas> listfacturasdet = new List<DetalleFacturas>();


            string query = @"SELECT ID_FACTURA_DETALLE, ID_FACTURA,ID_PRODUCTO, CANTIDAD, SUB_TOTAL, PRECIO_UNITARIO  
                                from FACTURAS_DETALLES
                                where (ID_FACTURA_DETALLE like @SEARCH or ID_FACTURA like @SEARCH or ID_PRODUCTO like @SEARCH
                                or CANTIDAD like @SEARCH or SUB_TOTAL like @SEARCH or PRECIO_UNITARIO like @SEARCH) 
                                order by PRECIO_UNITARIO desc
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
                        DetalleFacturas facturasDetalle = new DetalleFacturas();
                        facturasDetalle.IDFacturaDetalle = Convert.ToInt32(reader["ID_FACTURA_DETALLE"].ToString());
                        facturasDetalle.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        facturasDetalle.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                        facturasDetalle.Numero = Convert.ToDecimal(reader["CANTIDAD"].ToString().Trim());
                        facturasDetalle.SubTotal = Convert.ToDecimal(reader["SUB_TOTAL"].ToString().Trim());
                        facturasDetalle.PrecioUnitario = Convert.ToDecimal(reader["PRECIO_UNITARIO"].ToString().Trim());

                        listfacturasdet.Add(facturasDetalle);

                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return listfacturasdet;
        }

        public List<DetalleFacturas> GetListFacturaDetalle(int id)
        {
            List<DetalleFacturas> facturasDetalle = new List<DetalleFacturas>();


            string query = @"SELECT ID_FACTURA_DETALLE, ID_FACTURA,ID_PRODUCTO, CANTIDAD, SUB_TOTAL, PRECIO_UNITARIO  
                                from FACTURAS_DETALLES
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
                    while (reader.Read())
                    {
                        DetalleFacturas factDetalle = new DetalleFacturas();
                        factDetalle.IDFacturaDetalle = Convert.ToInt32(reader["ID_FACTURA_DETALLE"].ToString());
                        factDetalle.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        factDetalle.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                        factDetalle.Numero = Convert.ToDecimal(reader["CANTIDAD"].ToString().Trim());
                        factDetalle.SubTotal = Convert.ToDecimal(reader["SUB_TOTAL"].ToString().Trim());
                        factDetalle.PrecioUnitario = Convert.ToDecimal(reader["PRECIO_UNITARIO"].ToString().Trim());

                        facturasDetalle.Add(factDetalle);
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return facturasDetalle;
        }

        public DetalleFacturas GetFacturaDetalle(int idFactura, int idProducto)
        {
            DetalleFacturas facturasDetalle = new DetalleFacturas();


            string query = @"SELECT ID_FACTURA_DETALLE, ID_FACTURA,ID_PRODUCTO, CANTIDAD, SUB_TOTAL, PRECIO_UNITARIO  
                                from FACTURAS_DETALLES
                                where ID_FACTURA = @ID_FACTURA and ID_PRODUCTO=@ID_PRODUCTO
                            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", idProducto);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        facturasDetalle.IDFacturaDetalle = Convert.ToInt32(reader["ID_FACTURA_DETALLE"].ToString());
                        facturasDetalle.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        facturasDetalle.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                        facturasDetalle.Numero = Convert.ToDecimal(reader["CANTIDAD"].ToString().Trim());
                        facturasDetalle.SubTotal = Convert.ToDecimal(reader["SUB_TOTAL"].ToString().Trim());
                        facturasDetalle.PrecioUnitario = Convert.ToDecimal(reader["PRECIO_UNITARIO"].ToString().Trim());
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return facturasDetalle;
        }

        public List<int> AddFacturaDetalle(List<DetalleFacturas> facturasDetalle, int id)
        {
            List<int> insertedIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var detalle in facturasDetalle)
                {
                    using (SqlCommand cmd = new SqlCommand("MERGE INTO FACTURAS_DETALLES AS target " +
                                                          "USING (VALUES (@ID_FACTURA, @ID_PRODUCTO)) AS source (ID_FACTURA, ID_PRODUCTO) " +
                                                          "ON target.ID_FACTURA = source.ID_FACTURA AND target.ID_PRODUCTO = source.ID_PRODUCTO " +
                                                          "WHEN MATCHED THEN " +
                                                          "    UPDATE SET CANTIDAD = target.CANTIDAD + @CANTIDAD, " +
                                                          "               SUB_TOTAL = (target.CANTIDAD + @CANTIDAD) * @PRECIO_UNITARIO, " +
                                                          "               PRECIO_UNITARIO = @PRECIO_UNITARIO " +
                                                          "WHEN NOT MATCHED THEN " +
                                                          "    INSERT (ID_FACTURA, ID_PRODUCTO, CANTIDAD, SUB_TOTAL, PRECIO_UNITARIO) " +
                                                          "    VALUES (@ID_FACTURA, @ID_PRODUCTO, @CANTIDAD, @CANTIDAD * @PRECIO_UNITARIO, @PRECIO_UNITARIO) " +
                                                          "OUTPUT INSERTED.ID_FACTURA_DETALLE;", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_FACTURA", id);
                        cmd.Parameters.AddWithValue("@ID_PRODUCTO", detalle.IDProducto);
                        cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Numero);
                        cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", detalle.PrecioUnitario);

                        try
                        {
                            int insertedId = Convert.ToInt32(cmd.ExecuteScalar());
                            insertedIds.Add(insertedId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }

            return insertedIds;
        }

        public List<int> AddProducto(List<DetalleFacturas> facturasDetalle, IDS ids)
        {
            List<int> insertedIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var detalle in facturasDetalle)
                {
                    using (SqlCommand cmd = new SqlCommand("MERGE INTO FACTURAS_DETALLES AS target " +
                                                          "USING (VALUES (@ID_FACTURA, @ID_PRODUCTO)) AS source (ID_FACTURA, ID_PRODUCTO) " +
                                                          "ON target.ID_FACTURA = source.ID_FACTURA AND target.ID_PRODUCTO = source.ID_PRODUCTO " +
                                                          "WHEN MATCHED THEN " +
                                                          "    UPDATE SET CANTIDAD = target.CANTIDAD + @CANTIDAD, " +
                                                          "               SUB_TOTAL = (target.CANTIDAD + @CANTIDAD) * @PRECIO_UNITARIO, " +
                                                          "               PRECIO_UNITARIO = @PRECIO_UNITARIO " +
                                                          "WHEN NOT MATCHED THEN " +
                                                          "    INSERT (ID_FACTURA, ID_PRODUCTO, CANTIDAD, SUB_TOTAL, PRECIO_UNITARIO) " +
                                                          "    VALUES (@ID_FACTURA, @ID_PRODUCTO, @CANTIDAD, @CANTIDAD * @PRECIO_UNITARIO, @PRECIO_UNITARIO) " +
                                                          "OUTPUT INSERTED.ID_FACTURA_DETALLE;", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_FACTURA", ids.IDFactura);
                        cmd.Parameters.AddWithValue("@ID_PRODUCTO", ids.IDProducto);
                        cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Numero);
                        cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", detalle.PrecioUnitario);

                        try
                        {
                            int insertedId = Convert.ToInt32(cmd.ExecuteScalar());
                            insertedIds.Add(insertedId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }

            return insertedIds;
        }



        public int UpdateFacturaDetalle(DetalleFacturas facturasDetalle)
        {
            string query = "UPDATE FACTURAS_DETALLES SET CANTIDAD = @CANTIDAD," +
                " SUB_TOTAL = @SUB_TOTAL, PRECIO_UNITARIO = @PRECIO_UNITARIO " +
                "WHERE ID_FACTURA=@ID_FACTURA";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", facturasDetalle.IDFactura);
                cmd.Parameters.AddWithValue("@CANTIDAD", facturasDetalle.Numero);
                cmd.Parameters.AddWithValue("@SUB_TOTAL", facturasDetalle.SubTotal);
                cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", facturasDetalle.PrecioUnitario);

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

        public int DeleteFacturaDetalle(int id)
        {
            string query = "DELETE FACTURAS_DETALLES WHERE ID_FACTURA_DETALLE=@ID_FACTURA_DETALLE";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA_DETALLE", id);

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
