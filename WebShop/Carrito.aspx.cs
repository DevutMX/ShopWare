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

        Kernel _kernel = new Kernel();

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

                    pnlModificaciones.Visible = true;

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

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdProducto.Text != "")
                {
                    if (VerificarListado(Convert.ToInt32(txtIdProducto.Text)))
                    {
                        if (_bridge.QuitarDelCarrito(Convert.ToInt32(txtIdProducto.Text), Convert.ToInt32(Session["IdUsuario"])))
                        {
                            _kernel.MessageBox("Cantidad modificada", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }

                        else
                        {
                            _kernel.MessageBox("Ocurrió un error al modificar la cantidad", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                    }

                    else
                    {
                        _kernel.MessageBox("El producto no esta agregado en el carrito", this, this);

                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }

                else
                {
                    _kernel.MessageBox("Indique el codigo del producto a modificar", this, this);

                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            catch (Exception)
            {
                _kernel.MessageBox("El codigo del producto es inválido", this, this);

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdProducto.Text != "")
                {
                    if (VerificarListado(Convert.ToInt32(txtIdProducto.Text)))
                    {
                        string resultado = _bridge.AgregarAlCarrito(null, Convert.ToInt32(txtIdProducto.Text), Convert.ToInt32(Session["IdUsuario"]));

                        if (resultado == "Agregado")
                        {
                            _kernel.MessageBox("Se ha modificado la cantidad", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }

                        else if (resultado == "Existencias insuficientes")
                        {
                            _kernel.MessageBox("No se pudo modificar el carrito, debido a existencias insuficientes.", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }

                        else
                        {
                            _kernel.MessageBox("No se pudo modificar el producto", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                    }

                    else
                    {
                        _kernel.MessageBox("El producto no esta agregado en el carrito", this, this);

                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }

                else
                {
                    _kernel.MessageBox("Indique el codigo del producto a modificar", this, this);

                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }

            catch (Exception)
            {
                _kernel.MessageBox("El codigo del producto es inválido", this, this);

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdProducto.Text != "")
                {
                    if (VerificarListado(Convert.ToInt32(txtIdProducto.Text)))
                    {
                        if (_bridge.EliminarDelCarrito(Convert.ToInt32(txtIdProducto.Text), Convert.ToInt32(Session["IdUsuario"])))
                        {
                            _kernel.MessageBox("Se ha borrado el producto de tu carrito", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }

                        else
                        {
                            _kernel.MessageBox("No se pudo eliminar el producto", this, this);

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                    }

                    else
                    {
                        _kernel.MessageBox("El producto no esta agregado en el carrito", this, this);

                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }

                else
                {
                    _kernel.MessageBox("Indique el codigo del producto a modificar", this, this);

                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            catch (Exception)
            {
                _kernel.MessageBox("El codigo del producto es inválido", this, this);

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        private bool VerificarListado(int idproducto)
        {
            try
            {
                if (gdvCarrito.VisibleRowCount > 0)
                {
                    for (int i = 0; i < gdvCarrito.VisibleRowCount; i++)
                    {
                        if (idproducto == Convert.ToInt32(gdvCarrito.GetRowValues(i, "Cod. Producto")))
                        {
                            return true;
                        }
                    }

                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void btnPagarTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTarjeta.Text == "" || txtNombreTarjeta.Text == "" || txtMes.Text == "" || txtAno.Text == "" || txtCVV.Text == "")
                {
                    _kernel.MessageBox("", this, this);
                }

                else
                {

                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}