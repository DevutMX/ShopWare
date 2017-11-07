using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class Carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();
            
            _bridge.ListarCarrito(gdvCarrito, Convert.ToInt32(Session["IdUsuario"]));
        }

        Bridge _bridge = new Bridge();

        private void VerficarSesion()
        {
            try
            {
                if (Session["Usuario"] == null && Session["IdUsuario"] == null && Session["Privilegio"] == null)
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