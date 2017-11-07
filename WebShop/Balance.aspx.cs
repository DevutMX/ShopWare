using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class Balance : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();

            ObtenerSaldo();
        }

        Kernel _kernel = new Kernel();
        Bridge _bridge = new Bridge();

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

        private void ObtenerSaldo()
        {
            try
            {
                lblSaldo.Text = "$ " + _bridge.ObtenerSaldo(new Banco { Tarjeta = 4152312377392144L }).ToString() + " MXN";
            }
            catch (Exception)
            {
                
            }
        }
    }
}