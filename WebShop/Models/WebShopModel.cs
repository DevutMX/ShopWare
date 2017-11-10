using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebShop.Controllers;
using System.Web.UI;
using DevExpress.Web;

namespace WebShop.Models
{
    public class WebShopModel
    {
        //private readonly string _cadenaConexion = @"Server = DESKTOP-88ONNGE; Database = WebShop; Trusted_Connection = True;";

        private readonly string _cadenaConexion = @"Server = VICTORZ40; Database = WebShop; Trusted_Connection = True;";

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

        public int ObtenerExistencias(int idProducto)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Existencias FROM Productos WHERE Id = @a";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", idProducto);

                    leer = cmd.ExecuteReader();

                    int existencias = 0;

                    while (leer.Read())
                    {
                        existencias = Convert.ToInt32(leer[0]);
                    }

                    leer.Close();

                    return existencias;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string AgregarAlCarrito(EnCarrito compra, int idproducto, int usuario)
        {
            try
            {
                if (compra != null)
                {
                    int existencias = ObtenerExistencias(compra.IdProducto);
                    
                    if (existencias <= 0)
                    {
                        return "Existencias insuficientes";
                        //No hay existencias
                    }

                    else
                    {
                        int cantidad = CantidadProductoCarrito(compra.IdProducto, compra.Usuario);

                        if (cantidad <= 0)
                        {
                            using (cnn = new SqlConnection(_cadenaConexion))
                            {
                                string query = "INSERT INTO Carrito(IdProducto, Precio, Pagado, Ticket, Cantidad, Usuario) VALUES (@a, @b, @c, @d, @e, @f);";

                                cnn.Open();

                                cmd = new SqlCommand(query, cnn);
                                cmd.Parameters.AddWithValue("@a", compra.IdProducto);
                                cmd.Parameters.AddWithValue("@b", compra.Precio);
                                cmd.Parameters.AddWithValue("@c", compra.Pagado);
                                cmd.Parameters.AddWithValue("@d", compra.Ticket);
                                cmd.Parameters.AddWithValue("@e", 1);
                                cmd.Parameters.AddWithValue("@f", compra.Usuario);

                                if ((existencias - 1) >= 0)
                                {
                                    return cmd.ExecuteNonQuery() > 0 ? "Agregado" : "Error";
                                }

                                else
                                {
                                    return "Existencias insuficientes";
                                    //Insuficientes
                                }
                            }
                        }

                        else
                        {
                            using (cnn = new SqlConnection(_cadenaConexion))
                            {
                                string query = "UPDATE Carrito SET Cantidad = @a WHERE IdProducto = @b AND Ticket = @c AND Usuario = @d;";

                                cnn.Open();

                                cmd = new SqlCommand(query, cnn);
                                cmd.Parameters.AddWithValue("@a", cantidad + 1);
                                cmd.Parameters.AddWithValue("@b", compra.IdProducto);
                                cmd.Parameters.AddWithValue("@c", compra.Ticket);
                                cmd.Parameters.AddWithValue("@d", compra.Usuario);

                                if ((existencias - (cantidad + 1)) >= 0)
                                {
                                    return cmd.ExecuteNonQuery() > 0 ? "Agregado" : "Error";
                                }

                                else
                                {
                                    return "Existencias insuficientes";
                                    //Insuficientes
                                }
                            }
                        }
                    }
                }

                else
                {
                    int existencias = ObtenerExistencias(idproducto);

                    if (existencias <= 0)
                    {
                        return "Existencias insuficientes";
                        //No hay existencias
                    }

                    else
                    {
                        int cantidad = CantidadProductoCarrito(idproducto, usuario);

                        using (cnn = new SqlConnection(_cadenaConexion))
                        {
                            string query = "UPDATE Carrito SET Cantidad = @a WHERE IdProducto = @b AND Ticket = @c AND Usuario = @d;";

                            cnn.Open();

                            cmd = new SqlCommand(query, cnn);
                            cmd.Parameters.AddWithValue("@a", cantidad + 1);
                            cmd.Parameters.AddWithValue("@b", idproducto);
                            cmd.Parameters.AddWithValue("@c", "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX");
                            cmd.Parameters.AddWithValue("@d", usuario);

                            if ((existencias - (cantidad + 1)) >= 0)
                            {
                                return cmd.ExecuteNonQuery() > 0 ? "Agregado" : "Error";
                            }

                            else
                            {
                                return "Existencias insuficientes";
                                //Insuficientes
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public bool QuitarDelCarrito(int idproducto, int usuario)
        {
            try
            {
                int cantidad = CantidadProductoCarrito(idproducto, usuario);

                if (cantidad <= 1)
                {
                    using (cnn = new SqlConnection(_cadenaConexion))
                    {
                        string query = "DELETE FROM Carrito WHERE Carrito.IdProducto = @a AND Carrito.Ticket = @b AND Usuario = @c;";

                        cnn.Open();

                        cmd = new SqlCommand(query, cnn);
                        cmd.Parameters.AddWithValue("@a", idproducto);
                        cmd.Parameters.AddWithValue("@b", "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX");
                        cmd.Parameters.AddWithValue("@c", usuario);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }

                else
                {
                    using (cnn = new SqlConnection(_cadenaConexion))
                    {
                        string query = "UPDATE Carrito SET Cantidad = @a WHERE IdProducto = @b AND Ticket = @c AND Usuario = @d;";

                        cnn.Open();

                        cmd = new SqlCommand(query, cnn);
                        cmd.Parameters.AddWithValue("@a", cantidad - 1);
                        cmd.Parameters.AddWithValue("@b", idproducto);
                        cmd.Parameters.AddWithValue("@c", "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX");
                        cmd.Parameters.AddWithValue("@d", usuario);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarDelCarrito(int idproducto, int usuario)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "DELETE FROM Carrito WHERE idproducto = @a AND Ticket = @b AND Usuario = @c";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", idproducto);
                    cmd.Parameters.AddWithValue("@b", "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX");
                    cmd.Parameters.AddWithValue("@c", usuario);

                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CantidadProductoCarrito(int idproducto, int usuario)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Carrito.Cantidad FROM Carrito, Usuarios WHERE Carrito.IdProducto = @a AND Carrito.Ticket = @b AND Carrito.Usuario = @c AND Carrito.Pagado = 0 AND Usuarios.Id = Carrito.Usuario";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", idproducto);
                    cmd.Parameters.AddWithValue("@b", "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX");
                    cmd.Parameters.AddWithValue("@c", usuario);

                    leer = cmd.ExecuteReader();

                    int cantidad = 0;

                    while (leer.Read())
                    {
                        cantidad = Convert.ToInt32(leer[0]);
                    }

                    leer.Close();

                    return cantidad;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void ObtenerFormasPago(ASPxComboBox aRellenar)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Descripcion FROM TiposPago";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);

                    leer = cmd.ExecuteReader();

                    aRellenar.Items.Clear();

                    while (leer.Read())
                    {
                        aRellenar.Items.Add(leer[0].ToString());
                    }

                    leer.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        public bool AgregarFormaPago(TiposPago formaPago)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "INSERT INTO TiposPago(Descripcion, RequiereTarjeta) VALUES (@a, @b);";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", formaPago.Descripcion);
                    cmd.Parameters.AddWithValue("@b", formaPago.RequiereTarjeta);

                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BorrarFormaPago(string formaPago)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "DELETE From TiposPago WHERE Descripcion = @a;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", formaPago);

                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarUsoDatosBancarios(string formaPago)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT RequiereTarjeta From TiposPago WHERE Descripcion = @a";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", formaPago);

                    leer = cmd.ExecuteReader();

                    int requiere = 0;

                    while (leer.Read())
                    {
                        requiere = Convert.ToInt32(leer[0]);
                    }

                    leer.Close();

                    return requiere > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public decimal ObtenerSaldo(Banco datos)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Saldo FROM Banco WHERE Tarjeta = @a;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", datos.Tarjeta);

                    leer = cmd.ExecuteReader();

                    decimal saldo = 0m;

                    while (leer.Read())
                    {
                        saldo = Convert.ToDecimal(leer[0]);
                    }

                    leer.Close();

                    return saldo;
                }
            }
            catch (Exception)
            {
                return 0m;
            }
        }

        public void ListarCarrito(ASPxGridView aRellenar, int usuario)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Carrito.IdProducto as 'Cod. Producto', Carrito.Precio, Carrito.Cantidad, Usuarios.Usuario FROM Carrito, Usuarios WHERE Carrito.Ticket = @a AND Carrito.Usuario = @b AND Carrito.Pagado = 0 AND Usuarios.Id = Carrito.Usuario";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@a", "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX");
                    cmd.Parameters.AddWithValue("@b", usuario);

                    tabla = new DataTable();

                    adaptador = new SqlDataAdapter(cmd);

                    adaptador.Fill(tabla);

                    aRellenar.DataSource = tabla;

                    aRellenar.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        public void ListarClientes(ASPxGridView aRellenar)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Id, Usuario, Nombre, Apellidos, Telefono, Domicilio, Foto FROM DatosClientes;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);

                    tabla = new DataTable();

                    adaptador = new SqlDataAdapter(cmd);

                    adaptador.Fill(tabla);

                    aRellenar.DataSource = tabla;

                    aRellenar.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        public void ListarUsuarios(ASPxGridView aRellenar)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Id, Usuario, Correo, Privilegio FROM Usuarios;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);

                    tabla = new DataTable();

                    adaptador = new SqlDataAdapter(cmd);

                    adaptador.Fill(tabla);

                    aRellenar.DataSource = tabla;

                    aRellenar.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        public void ListarVentas(ASPxGridView aRellenar)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "SELECT Venta.Ticket as 'Ticket', Venta.Total as 'Total', TiposPago.Descripcion as 'Forma de pago', DatosClientes.Nombre as 'Nombre', DatosClientes.Apellidos as 'Apellidos' FROM Venta, TiposPago, DatosClientes WHERE TiposPago.Tipo = Venta.TipoPago AND DatosClientes.Id = Venta.Cliente;";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);

                    tabla = new DataTable();

                    adaptador = new SqlDataAdapter(cmd);

                    adaptador.Fill(tabla);

                    aRellenar.DataSource = tabla;

                    aRellenar.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        public bool RegistrarVenta(Venta venta)
        {
            try
            {
                using (cnn = new SqlConnection(_cadenaConexion))
                {
                    string query = "INSERT INTO Venta VALUES(@a, @b, @c, @d)";

                    cnn.Open();

                    cmd = new SqlCommand(query, cnn);

                    cmd.Parameters.AddWithValue("@a", venta.Ticket);
                    cmd.Parameters.AddWithValue("@b", venta.Total);
                    cmd.Parameters.AddWithValue("@c", venta.TipoPago);
                    cmd.Parameters.AddWithValue("@d", venta.Cliente);

                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}