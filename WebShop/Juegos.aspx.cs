﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class Juegos : Page
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

        protected void btnDoom_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("DOOM", 1, 699m);
        }

        protected void btnStarWars_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Star Wars Battlefront II", 2, 1399m);
        }

        protected void btnBattlefield_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Battlefield 1", 3, 800m);
        }

        protected void btnYooka_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Yooka & Laylee", 4, 459m);
        }

        protected void btnWolfenstein_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Wolfenstein II The new colossus", 5, 1099m);
        }
    }
}