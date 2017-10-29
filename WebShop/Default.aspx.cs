using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop {
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        Kernel _kernel = new Kernel();

        private void VerificarUsuarioParaAgregarProducto(int producto)
        {
            try
            {
                if (Session["Usuario"] != null && Session["IdUsuario"] != null && Session["Privilegio"] != null)
                {
                    _kernel.MessageBox("Bienvenido " + Session["Usuario"], this, this);
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
            VerificarUsuarioParaAgregarProducto(1);
        }

        protected void btnWindows_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto(6);
        }

        protected void btnBattlefield_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto(3);
        }

        protected void btnOffice_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto(8);
        }

        protected void btnWolfenstein_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto(5);
        }
    }
}