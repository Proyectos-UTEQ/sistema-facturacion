using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Facturacion.Models;
using Facturacion.DataAccess;
using System.Data;

namespace Facturacion.models
{
   

    public class ProductoRespositorio : ConexionBD
    {

        public ProductoRespositorio()
        {
        }

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

        public DataTable ObtenerListaProductos(string palabra, string campo)
        {
            // List<Producto> productos = new List<Producto>();

            string query = $@"SELECT ID_PRODUCTO, TRIM(NOMBRE) AS NOMBRE, COSTO, PRECIO FROM PRODUCTO WHERE {campo} LIKE @SEARCH and ESTADO = 1 order by {campo} asc";

            // string query = @"SELECT ID_PRODUCTO, NOMBRE, COSTO, PRECIO, ESTADO FROM PRODUCTO WHERE (NOMBRE like @SEARCH or COSTO like @SEARCH or PRECIO like @SEARCH) and ESTADO = 1 order by NOMBRE asc";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SEARCH", "%" + palabra + "%")
            };

            DataTable data = EjecutarConsulta(query, parameters);
            return data;

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@SEARCH", "%" + palabra + "%");
            //    try
            //    {
            //        conn.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            Producto producto = new Producto();
            //            producto.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
            //            producto.Nombre = reader["NOMBRE"].ToString().Trim();
            //            producto.Costo = Decimal.Parse(reader["COSTO"].ToString());
            //            producto.Precio = Decimal.Parse(reader["PRECIO"].ToString());
            //            producto.Estado = reader["ESTADO"].ToString().ToLower() == "true" ? 1 : 0;

            //            productos.Add(producto);

            //        }
            //        conn.Close();

            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //}

            //return productos;
        }

        public Producto GetProducto(int id)
        {
            Producto producto = new Producto();

            string query = @"SELECT ID_PRODUCTO, NOMBRE, COSTO, PRECIO, ESTADO FROM PRODUCTO WHERE ID_PRODUCTO = @ID_PRODUCTO";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", id);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        producto.IDProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                        producto.Nombre = reader["NOMBRE"].ToString().Trim();
                        producto.Costo = Decimal.Parse(reader["COSTO"].ToString());
                        producto.Precio = Decimal.Parse(reader["PRECIO"].ToString());
                        producto.Estado = reader["ESTADO"].ToString().ToLower() == "true" ? 1 : 0;
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return producto;
        }

        public int AgregarProducto(Producto producto)
        {

            string query = "INSERT INTO PRODUCTO(NOMBRE, COSTO, PRECIO, ESTADO) OUTPUT Inserted.ID_PRODUCTO values(@NOMBRE, @COSTO, @PRECIO, @ESTADO)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Crear comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                cmd.Parameters.AddWithValue("@COSTO", producto.Costo);
                cmd.Parameters.AddWithValue("@PRECIO", producto.Precio);
                cmd.Parameters.AddWithValue("@ESTADO", producto.Estado);

                try
                {
                    conn.Open();
                    // Ejecutar comando.
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Obtener ID del cliente.
                        return Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
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

        public int ActualizarProducto(Producto producto)
        {
            string query = "UPDATE PRODUCTO SET NOMBRE = @NOMBRE, COSTO = @COSTO, PRECIO = @PRECIO, ESTADO = @ESTADO WHERE ID_PRODUCTO=@ID_PRODUCTO";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                cmd.Parameters.AddWithValue("@COSTO", producto.Costo);
                cmd.Parameters.AddWithValue("@PRECIO", producto.Precio);
                cmd.Parameters.AddWithValue("@ESTADO", producto.Estado);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", producto.IDProducto);

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

        public int EliminarProducto(int id)
        {
            string query = "UPDATE PRODUCTO SET ESTADO = 0 WHERE ID_PRODUCTO=@ID_PRODUCTO";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", id);

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
