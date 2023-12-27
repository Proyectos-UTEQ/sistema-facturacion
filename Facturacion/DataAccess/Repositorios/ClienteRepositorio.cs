using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Facturacion.Models;
using Facturacion.DataAccess;

namespace Facturacion.models
{
    // Repositorio de clientes.
    public class ClienteRepositorio : DbContext
    {

        public ClienteRepositorio() {
            
        }

        // Probar conexión.
        public async Task<bool> Ok()
        {
            try {
                SqlConnection conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                conn.Close();
            } catch
            {
                return false;
            }
            return true;
        }

        // Obtener lista de clientes.
        public List<Cliente> ObtenerClientes(string search)
        {
            List<Cliente> clientes = new List<Cliente>();

            string query = @"SELECT ID_CLIENTE, CEDULA, NOMBRES, APELLIDOS, TELEFONO 
                                from CLIENTE
                                where (CEDULA like @SEARCH or NOMBRES like @SEARCH or APELLIDOS like @SEARCH or TELEFONO like @SEARCH) and ESTADO = 1
                                order by APELLIDOS asc
                            ";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {

                // Crear comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SEARCH", "%" + search + "%");

                try {
                    
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Recuperar datos.
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                        cliente.Cedula = reader["CEDULA"].ToString().Trim();
                        cliente.Nombres = reader["NOMBRES"].ToString().Trim();
                        cliente.Apellidos = reader["APELLIDOS"].ToString().Trim();
                        cliente.Telefonos = reader["TELEFONO"].ToString().Trim();

                        clientes.Add(cliente);

                    }
                    conn.Close();

                } catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return clientes;
        }

        // Obtener cliente de la base de datos.
        public Cliente ObtenerCliente(int id)
        {
            Cliente cliente = new Cliente();

            string query = @"SELECT ID_CLIENTE, CEDULA, NOMBRES, APELLIDOS, TELEFONO 
                                from CLIENTE
                                where ID_CLIENTE = @ID_CLIENTE
                            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Recuperar datos.
                    if (reader.Read())
                    {
                        cliente.IDCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                        cliente.Cedula = reader["CEDULA"].ToString();
                        cliente.Nombres = reader["NOMBRES"].ToString();
                        cliente.Apellidos = reader["APELLIDOS"].ToString();
                        cliente.Telefonos = reader["TELEFONO"].ToString();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return cliente;
        }

        // Agregar cliente a la base de datos.
        public int AgregarCliente(Cliente cliente) {
            
            string query = "INSERT INTO CLIENTE(CEDULA, NOMBRES, APELLIDOS, TELEFONO) OUTPUT Inserted.ID_CLIENTE values(@CEDULA, @NOMBRES, @APELLIDOS, @TELEFONO)";

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
                    var id = 0;
                    if (reader.Read())
                    {
                        // Obtener ID del cliente.
                        id = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                    }
                    conn.Close();
                    return id;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        // Actualizar cliente en la base de datos.
        public int ActualizarCliente(Cliente cliente)
        {
            string query = "UPDATE CLIENTE SET CEDULA = @CEDULA, NOMBRES = @NOMBRES, APELLIDOS = @APELLIDOS, TELEFONO = @TELEFONO " +
                "WHERE ID_CLIENTE=@ID_CLIENTE";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                // Pasamos los parámetros al comando.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
                cmd.Parameters.AddWithValue("@NOMBRES", cliente.Nombres);
                cmd.Parameters.AddWithValue("@APELLIDOS", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@TELEFONO", cliente.Telefonos);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", cliente.IDCliente);

                try
                {
                    conn.Open();
                    var rowAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowAffected;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        // Eliminar cliente en la base de datos. simplemente desabilita el cliente.
        public int EliminarCliente(int id)
        {

            string query = "UPDATE CLIENTE SET ESTADO = 0 WHERE ID_CLIENTE=@ID_CLIENTE";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", id);

                try
                {
                    conn.Open();
                    var rowAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowAffected;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }

   
}
