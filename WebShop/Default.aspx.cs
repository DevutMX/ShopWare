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
        Bridge _bridge = new Bridge();

        private void VerificarUsuarioParaAgregarProducto(string nombre, int producto, decimal precio)
        {
            try
            {
                if (Session["Usuario"] != null && Session["IdUsuario"] != null && Session["Privilegio"] != null)
                {
                    string resultado = _bridge.AgregarAlCarrito(new EnCarrito { IdProducto = producto, Precio = precio, Pagado = 0, Usuario = Convert.ToInt32(Session["IdUsuario"]), Ticket = "WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX" }, 0, 0);

                    if (resultado == "Agregado")
                    {
                        _kernel.MessageBox("Se ha agregado " + nombre + " al carrito.", this, this);
                    }

                    else if(resultado == "Existencias insuficientes")
                    {
                        _kernel.MessageBox("No se pudo agregar " + nombre + " al carrito, debido a existencias insuficientes.", this, this);
                    }

                    else
                    {
                        _kernel.MessageBox("No se pudo agregar " + nombre + " al carrito.", this, this);
                    }
                }

                else
                {
                    _kernel.MessageBox("Por favor inicia sesi�n para poder comprar", this, this);

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

        protected void btnWindows_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Microsoft Windows 10", 6, 2919m);
        }

        protected void btnBattlefield_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Battlefield 1", 3, 800m);
        }

        protected void btnOffice_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Microsoft Office 2016 Professional", 8, 3500m);
        }

        protected void btnWolfenstein_Click(object sender, EventArgs e)
        {
            VerificarUsuarioParaAgregarProducto("Wolfenstein II The new colossus", 5, 1099m);
        }
    }
}