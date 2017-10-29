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
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();
        }

        private void VerficarSesion()
        {
            try
            {
                if (Session["Usuario"] != null && Session["IdUsuario"] != null && Session["Privilegio"] != null)
                {
                    if (Session["Privilegio"].ToString() != "Administrador")
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();

                Thread.Sleep(2000);

                Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                
            }
        }
    }
}