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

    public class FacturaDetallesRepositorio : ConexionBD
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

        // Obtener todas las facturas de la base de datos.
        // Para realizar busquedas por campos especiales.
        public List<FacturaDetalles> ObtenerFacturaDetalles(string search)
        {
            List<FacturaDetalles> listfacturasdet = new List<FacturaDetalles>();


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
                        FacturaDetalles facturasDetalle = new FacturaDetalles();
                        facturasDetalle.IDFacturaDetalle = Convert.ToInt32(reader["ID_FACTURA_DETALLE"].ToString());
                        facturasDetalle.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        facturasDetalle.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                        facturasDetalle.Cantidad = Convert.ToDecimal(reader["CANTIDAD"].ToString().Trim());
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


        // Obtener el detalle de una factura, tambien para realizar busquedas por campos especiales.
        public List<FacturaDetalles> ObtenerDetalle(int id, string search = "")
        {
            List<FacturaDetalles> facturasDetalle = new List<FacturaDetalles>();


            string query = @"SELECT ID_FACTURA_DETALLE, ID_FACTURA, ID_PRODUCTO, CANTIDAD, SUB_TOTAL, PRECIO_UNITARIO  
                                FROM FACTURAS_DETALLES
                                WHERE ID_FACTURA = @ID_FACTURA AND (ID_PRODUCTO like @SEARCH or CANTIDAD like @SEARCH or SUB_TOTAL like @SEARCH or PRECIO_UNITARIO like @SEARCH)
                            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", id);
                cmd.Parameters.AddWithValue("@SEARCH", "%" + search + "%");
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FacturaDetalles factDetalle = new FacturaDetalles();
                        factDetalle.IDFacturaDetalle = Convert.ToInt32(reader["ID_FACTURA_DETALLE"].ToString());
                        factDetalle.IDFactura = Convert.ToInt32(reader["ID_FACTURA"].ToString());
                        factDetalle.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                        factDetalle.Cantidad = Convert.ToDecimal(reader["CANTIDAD"].ToString().Trim());
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

        public FacturaDetalles GetFacturaDetalle(int idFactura, int idProducto)
        {
            FacturaDetalles facturasDetalle = new FacturaDetalles();


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
                        facturasDetalle.Cantidad = Convert.ToDecimal(reader["CANTIDAD"].ToString().Trim());
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

        public List<int> AddFacturaDetalle(List<FacturaDetalles> facturasDetalle, int id)
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
                        cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
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

        public List<int> AddProducto(List<FacturaDetalles> facturasDetalle, IDS ids)
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
                        cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
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

        public void EliminarDetallePorID(int id)
        {
            string query = "DELETE FROM FACTURAS_DETALLES WHERE ID_FACTURA=@ID_FACTURA";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }



        public int UpdateFacturaDetalle(FacturaDetalles facturasDetalle)
        {
            string query = "UPDATE FACTURAS_DETALLES SET CANTIDAD = @CANTIDAD," +
                " SUB_TOTAL = @SUB_TOTAL, PRECIO_UNITARIO = @PRECIO_UNITARIO " +
                "WHERE ID_FACTURA=@ID_FACTURA";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_FACTURA", facturasDetalle.IDFactura);
                cmd.Parameters.AddWithValue("@CANTIDAD", facturasDetalle.Cantidad);
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

        public void DeleteFacturaDetalle(int id)
        {
            string query = "DELETE FACTURAS_DETALLES WHERE ID_FACTURA_DETALLE=@ID_FACTURA_DETALLE";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ID_FACTURA_DETALLE", id)
            };

            EjecutarComando(query, parameters);
        }

        public void RegistrarDetalleFactura(Factura factura) 
        {
            // detalles que se van a crear o insertar en la base de datos
            var crear = factura.Detalles.Where(detalle => detalle.IDFacturaDetalle == 0).ToList();
            Insertar(factura.IDFactura, crear);

            // detalles que se van a actualizar.
            var actualizar = factura.Detalles.Where(detalle => detalle.IDFacturaDetalle != 0).ToList();
            // actualizar los detalles.
            Actualizar(factura.IDFactura, actualizar);
        }

        public void Insertar(int idfactura, List<FacturaDetalles> detalles) 
        {
            // insertar detalle de una factura.
            string query = "INSERT INTO FACTURAS_DETALLES(ID_FACTURA, ID_PRODUCTO, DESCRIPCION, CANTIDAD, PRECIO_UNITARIO, SUB_TOTAL)" +
                " VALUES(@ID_FACTURA, @ID_PRODUCTO, @DESCRIPCION, @CANTIDAD, @PRECIO_UNITARIO, @SUB_TOTAL)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Crear comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ID_FACTURA", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@ID_PRODUCTO", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@CANTIDAD", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@PRECIO_UNITARIO", System.Data.SqlDbType.Decimal);
                cmd.Parameters.Add("@SUB_TOTAL", System.Data.SqlDbType.Decimal);

                foreach (var detalle in detalles)
                { 
                    cmd.Parameters["@ID_FACTURA"].Value = idfactura;
                    cmd.Parameters["@ID_PRODUCTO"].Value = detalle.IDProducto;
                    cmd.Parameters["@DESCRIPCION"].Value = detalle.Descripcion;
                    cmd.Parameters["@CANTIDAD"].Value = detalle.Cantidad;
                    cmd.Parameters["@PRECIO_UNITARIO"].Value = detalle.PrecioUnitario;
                    cmd.Parameters["@SUB_TOTAL"].Value = detalle.SubTotal;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void Actualizar(int idfactura, List<FacturaDetalles> detalles)
        {
            // insertar detalle de una factura.
            string query = "UPDATE FACTURAS_DETALLES SET ID_FACTURA=@ID_FACTURA, ID_PRODUCTO=@ID_PRODUCTO, DESCRIPCION=@DESCRIPCION, CANTIDAD=@CANTIDAD, PRECIO_UNITARIO=@PRECIO_UNITARIO, SUB_TOTAL=@SUB_TOTAL" +
                " WHERE ID_FACTURA_DETALLE=@ID_FACTURA_DETALLE";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Crear comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ID_FACTURA", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@ID_PRODUCTO", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@CANTIDAD", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@PRECIO_UNITARIO", System.Data.SqlDbType.Decimal);
                cmd.Parameters.Add("@SUB_TOTAL", System.Data.SqlDbType.Decimal);
                cmd.Parameters.Add("@ID_FACTURA_DETALLE", System.Data.SqlDbType.Int);

                foreach (var detalle in detalles)
                {
                    cmd.Parameters["@ID_FACTURA"].Value = idfactura;
                    cmd.Parameters["@ID_PRODUCTO"].Value = detalle.IDProducto;
                    cmd.Parameters["@DESCRIPCION"].Value = detalle.Descripcion;
                    cmd.Parameters["@CANTIDAD"].Value = detalle.Cantidad;
                    cmd.Parameters["@PRECIO_UNITARIO"].Value = detalle.PrecioUnitario;
                    cmd.Parameters["@SUB_TOTAL"].Value = detalle.SubTotal;
                    cmd.Parameters["@ID_FACTURA_DETALLE"].Value = detalle.IDFacturaDetalle;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
