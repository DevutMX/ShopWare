using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop {
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) {

        }

        private void VerificarUsuarioParaAgregarProducto(int producto)
        {
            try
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Aviso", "alert('Por favor inicia sesión para comprar')", true);

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