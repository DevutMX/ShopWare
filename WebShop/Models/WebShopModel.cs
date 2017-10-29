using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebShop.Controllers;
using System.Web.UI;

namespace WebShop.Models
{
    public class WebShopModel
    {
        private readonly string _cadenaConexion = @"Server = DESKTOP-88ONNGE; Database = WebShop; Trusted_Connection = True;";

        Kernel _kernel = new Kernel();

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adaptador;
        SqlDataReader leer;
        DataTable tabla;

        private bool AltaUsuario(DatosClientes cliente)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "INSERT INTO Usuarios(Usuario, Contrasena, Correo, Privilegio) VALUES (@a, @b, @c, @d);";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", cliente.Usuario);
                    cmd.Parameters.AddWithValue("@b", cliente.Contrasena);
                    cmd.Parameters.AddWithValue("@c", cliente.Correo);
                    cmd.Parameters.AddWithValue("@d", cliente.Privilegio);

                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int ObtenerIdUsuario(DatosClientes cliente)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Id FROM Usuarios WHERE Usuario = @a AND Contrasena = @b AND Correo = @c AND Privilegio = @d;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", cliente.Usuario);
                    cmd.Parameters.AddWithValue("@b", cliente.Contrasena);
                    cmd.Parameters.AddWithValue("@c", cliente.Correo);
                    cmd.Parameters.AddWithValue("@d", cliente.Privilegio);

                    leer = cmd.ExecuteReader();

                    int id = 0;

                    while (leer.Read())
                    {
                        id = Convert.ToInt32(leer[0]);
                    }

                    leer.Close();

                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AltaCliente(DatosClientes cliente)
        {
            try
            {
                if (AltaUsuario(cliente))
                {
                    int id = ObtenerIdUsuario(cliente);

                    if (id > 0)
                    {
                        using (cnn = new SqlConnection(_cadenaConexion))
                        {
                            string query = "INSERT INTO DatosClientes(Usuario, Nombre, Apellidos, Telefono, Domicilio, Foto, Tarjeta, Mes, Ano, CVV) VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i, @j);";

                            cnn.Open();

                            cmd = new SqlCommand(query, cnn);
                            cmd.Parameters.AddWithValue("@a", id);
                            cmd.Parameters.AddWithValue("@b", cliente.Nombre);
                            cmd.Parameters.AddWithValue("@c", cliente.Apellidos);
                            cmd.Parameters.AddWithValue("@d", cliente.Telefono);
                            cmd.Parameters.AddWithValue("@e", cliente.Domicilio);
                            cmd.Parameters.AddWithValue("@f", cliente.Foto);
                            cmd.Parameters.AddWithValue("@g", cliente.Tarjeta);
                            cmd.Parameters.AddWithValue("@h", cliente.Mes);
                            cmd.Parameters.AddWithValue("@i", cliente.Ano);
                            cmd.Parameters.AddWithValue("@j", cliente.CVV);

                            return cmd.ExecuteNonQuery() > 0 ? true : false;
                            
                        }
                    }

                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string[] ObtenerAcceso(DatosClientes cliente)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Id, Usuario, Privilegio FROM Usuarios WHERE Usuario = @a AND Contrasena = @b;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", cliente.Usuario);
                    cmd.Parameters.AddWithValue("@b", cliente.Contrasena);

                    leer = cmd.ExecuteReader();

                    string[] datos = new string[3];

                    while (leer.Read())
                    {
                        datos[0] = leer[0].ToString();
                        datos[1] = leer[1].ToString();
                        datos[2] = leer[2].ToString();
                    }

                    leer.Close();

                    return datos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}