﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();

            _bridge.ListarVentas(gdvVentas);
        }

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
    }
}