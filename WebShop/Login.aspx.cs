using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();
        }

        Kernel _kernel = new Kernel();
        Secret _secret = new Secret();
        Bridge _bridge = new Bridge();

        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "" || txtContrasena.Text == "")
                {
                    _kernel.MessageBox("Es necesario que proporcione todos sus datos.", this, this);
                }

                else
                {
                    string[] datos = _bridge.ObtenerAcceso(new DatosClientes { Usuario = txtUsuario.Text, Contrasena = _secret.Cifrar(txtContrasena.Text) });

                    if (datos != null)
                    {
                        Session["IdUsuario"] = Convert.ToInt32(datos[0]);
                        Session["Usuario"] = datos[1];
                        Session["Privilegio"] = datos[2];

                        Thread.Sleep(2000);

                        Response.Redirect("~/Default.aspx");
                    }

                    else
                    {
                        _kernel.MessageBox("Datos incorrectos, verifique por favor", this, this);
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