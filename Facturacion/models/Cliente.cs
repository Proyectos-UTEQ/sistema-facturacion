using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Facturacion.models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos { get; set; }
    }

    public class ClienteDB
    {
        private string connectionString = string.Empty;

        public ClienteDB() {
            this.connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        }

        // Probar conexión.
        public bool Ok()
        {
            try {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            string query = "select ID_CLIENTE, CEDULA, NOMBRES, APELLIDOS, TELEFONO from CLIENTE";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                        cliente.Cedula = reader["CEDULA"].ToString();
                        cliente.Nombres = reader["NOMBRES"].ToString();
                        cliente.Apellidos = reader["APELLIDOS"].ToString();
                        cliente.Telefonos = reader["TELEFONO"].ToString();

                        clientes.Add(cliente);

                    }

                } catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return clientes;
        }

        public int AddUser(Cliente cliente) {
            
            string query = "insert into CLIENTE(CEDULA, NOMBRES, APELLIDOS, TELEFONO) OUTPUT Inserted.ID_CLIENTE values(@CEDULA, @NOMBRES, @APELLIDOS, @TELEFONO)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Crear comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
                cmd.Parameters.AddWithValue("@NOMBRES", cliente.Nombres);
                cmd.Parameters.AddWithValue("@APELLIDOS", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@TELEFONO", cliente.Telefonos);

                try
                {
                    conn.Open();
                    // Ejecutar comando.
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Obtener ID del cliente.
                        return Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                    } else
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

        public int UpdateUser(Cliente cliente)
        {
            string query = "UPDATE CLIENTE SET CEDULA = @CEDULA, NOMBRES = @NOMBRES, APELLIDOS = @APELLIDOS, TELEFONO = @TELEFONO " +
                "WHERE ID_CLIENTE=@ID_CLIENTE";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
                cmd.Parameters.AddWithValue("@NOMBRES", cliente.Nombres);
                cmd.Parameters.AddWithValue("@APELLIDOS", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@TELEFONO", cliente.Telefonos);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", cliente.IDCliente);

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
