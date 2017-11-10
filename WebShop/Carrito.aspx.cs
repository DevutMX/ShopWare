using DevExpress.Web;
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

            CalcularTotal();

            CargarFormasPago();
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

        private void CalcularTotal()
        {
            try
            {
                if (gdvCarrito.VisibleRowCount > 0)
                {
                    decimal total = 0M;

                    int productos = 0;

                    for (int i = 0; i < gdvCarrito.VisibleRowCount; i++)
                    {
                        total += Convert.ToDecimal(gdvCarrito.GetRowValues(i, "Precio")) * Convert.ToDecimal( gdvCarrito.GetRowValues(i, "Cantidad"));

                        productos += Convert.ToInt32(gdvCarrito.GetRowValues(i, "Cantidad"));
                    }

                    lblSubtotal.Text = "$ " + (total - (total * 0.16M));

                    lblIVA.Text = "$ " + (total * 0.16M);

                    lblTotal.Text = "$ " + total.ToString();

                    pnlTotal.Visible = true;

                    lblTicket.Text = "Ticket: WebShop-" + DateTime.Now.ToString("ddMMyy") + "-DMX";

                    lblProductosAgregados.Text = "Tienes " + productos.ToString() + " productos en el carrito.";

                    lblTicket.Visible = true;

                    lblProductosAgregados.Visible = true;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void CargarFormasPago()
        {
            try
            {
                _bridge.ObtenerFormasPago(cbxFormasPago);
            }
            catch (Exception)
            {

            }
        }

        protected void cbxFormasPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_bridge.VerificarUsoDatosBancarios(cbxFormasPago.Text))
                {
                    btnPagar.Visible = false;

                    pnlDatosBancarios.Visible = true;
                }

                else
                {
                    pnlDatosBancarios.Visible = false;

                    btnPagar.Visible = true;
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

        }
    }
}