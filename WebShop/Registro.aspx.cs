using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class Registro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();
        }

        Secret _secret = new Secret();
        Kernel _kernel = new Kernel();
        Bridge _bridge = new Bridge();
        
        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnRegistrarte_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "" || txtApellidos.Text == "" || txtDomicilio.Text == "" || txtCorreo.Text == "" ||  txtTelefono.Text == "" || txtUsuario.Text == "" || txtPassword.Text == "")
                {
                    _kernel.MessageBox("Todos los datos son necesarios para realizar el registro", this, this);
                }

                else
                {
                    if (_bridge.AltaCliente(new DatosClientes { Nombre = txtNombre.Text, Apellidos = txtApellidos.Text, Domicilio = txtDomicilio.Text, Correo = txtCorreo.Text, Tarjeta = 1, Ano = 2017, Contrasena = _secret.Cifrar(txtPassword.Text), CVV = 1, Mes = 1, Foto = new byte[0], Telefono = txtTelefono.Text, Privilegio = "Cliente", Usuario = txtUsuario.Text }))
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    else
                    {
                        _kernel.MessageBox("Ocurrio un error al registrarte, verifica los datos", this, this);
                    }
                }
            }
            catch (Exception ex)
            {
                _kernel.MessageBox(ex.ToString(), this, this);
            }
        }

        private void VerficarSesion()
        {
            try
            {
                if (Session["Usuario"] != null && Session["IdUsuario"] != null && Session["Privilegio"] != null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}