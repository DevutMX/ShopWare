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
    public partial class Software : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Kernel _kernel = new Kernel();
        Bridge _bridge = new Bridge();

        private void VerificarUsuarioParaAgregarProducto(string nombre, int producto, decimal precio)
        {
            try
            {
                if (Session["Usuario"] != null && Session["IdUsuario"] != null && Session["Privilegio"] != null)
                {
                    if (_bridge.AgregarAlCarrito(new EnCarrito { IdProducto = producto, Precio = precio, Usuario = Convert.ToInt32(Session["IdUsuario"]), Ticket = "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX" }))
                    {
                        _kernel.MessageBox("Se ha agregado " + nombre + " al carrito.", this, this);
                    }

                    else
                    {
                        _kernel.MessageBox("No se pudo agregar " + nombre + " al carrito.", this, this);
                    }
                }

                else
                {
                    _kernel.MessageBox("Por favor inicia sesión para poder comprar", this, this);

                    Thread.Sleep(2000);

                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnwindows_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Microsoft Windows 10", 6, 2919m);
        }

        protected void btnVisual_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Microsoft Visual Studio 2017 Enterprise", 7, 127000m);
        }

        protected void btnOffice_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Microsoft Office 2016 Professional", 8, 3500m);
        }

        protected void btnSQL_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Microsoft SQL Server 2016", 9, 67000m);
        }

        protected void btnAdobe_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Adobe Creative Cloud 1 año", 10, 32000m);
        }
    }
}