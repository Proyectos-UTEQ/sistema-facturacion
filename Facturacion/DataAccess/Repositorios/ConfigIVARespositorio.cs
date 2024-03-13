using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.DataAccess.Repositorios
{
    public class ConfigIVARespositorio : ConexionBD
    {

        public ConfigIVARespositorio() { }

        // Recuperamos la tabla de config iva.
        public DataTable ObtenerConfigIVA()
        { 
            string query = "SELECT ID_IVA, VALOR_IVA, RIGE_DESDE FROM CONFIG_IVA WHERE ELIMINADO=0 ORDER BY RIGE_DESDE DESC;";
            DataTable data = EjecutarConsulta(query);
            return data;
        }

        // Eliminamos un registro de config iva.
        public bool EliminarConfigIVA(int id)
        {
            string query = "UPDATE CONFIG_IVA SET ELIMINADO = 1 WHERE ID_IVA = @ID_IVA;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_IVA", id);

                try {
                    conn.Open();
                    var rowAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowAffected == 1;
                } catch (Exception ex) {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void NuevoConfigIVA(decimal iva, DateTime date)
        {
            string query = "EXEC REGISTRAR_NUEVO_CONFIG_IVA @IVA = @IVA, @RIGE_DESDE = @RIGE_DESDE;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            { 

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IVA", iva);
                cmd.Parameters.AddWithValue("@RIGE_DESDE", date);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }    
        }

        public void UpdateConfigIVA(ConfigIVA config)
        {
            string query = "UPDATE CONFIG_IVA SET VALOR_IVA = @IVA, RIGE_DESDE = @RIGE_DESDE WHERE ID_IVA = @ID_IVA;";

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IVA", config.VALOR_IVA);
                cmd.Parameters.AddWithValue("@RIGE_DESDE", config.RIGE_DESDE);
                cmd.Parameters.AddWithValue("@ID_IVA", config.ID_IVA);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally 
                {
                    conn.Close();
                }
            }
        }

        public ConfigIVA ConfigIVA(int id)
        {
            ConfigIVA config = new ConfigIVA();
            string query = "SELECT ID_IVA, VALOR_IVA, RIGE_DESDE, ELIMINADO FROM CONFIG_IVA WHERE ID_IVA=@ID_IVA;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_IVA", id);

                try
                {
                    conn.Open();
                    // Ejecutamos el comando, y recuperamos los datos.
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        config.ID_IVA = Convert.ToInt32(reader["ID_IVA"]);
                        config.VALOR_IVA = Convert.ToDecimal(reader["VALOR_IVA"]);
                        config.RIGE_DESDE = Convert.ToDateTime(reader["RIGE_DESDE"]);
                        config.ELIMINADO = Convert.ToBoolean(reader["ELIMINADO"]);
                    }

                    conn.Close();
                }
                catch (Exception ex) { 
                    throw ex;
                }
            }

            return config;
        }

        public ConfigIVA getConfigIVAByDate(DateTime date)
        { 
            ConfigIVA config = new ConfigIVA();
            string query = "EXEC OBTENER_CONFIG_IVA @FECHA = @FECHA;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            { 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FECHA", date);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        config.ID_IVA = Convert.ToInt32(reader["ID_IVA"]);
                        config.VALOR_IVA = Convert.ToDecimal(reader["VALOR_IVA"]);
                        config.RIGE_DESDE = Convert.ToDateTime(reader["RIGE_DESDE"]);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return config;
        }

    }
}
