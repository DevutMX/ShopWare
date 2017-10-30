using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop.Controllers;

namespace WebShop
{
    public partial class FormasPago : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerficarSesion();

            CargarFormasPago();
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFormaPago.Text != "")
                {
                    if (_bridge.AgregarFormaPago(new TiposPago { Descripcion = txtFormaPago.Text, RequiereTarjeta = chkRequiereTarjeta.Checked ? 1 : 0 }))
                    {
                        _kernel.MessageBox("Listo, forma de pago agregada", this, this);

                        CargarFormasPago();
                    }

                    else
                    {
                        _kernel.MessageBox("No fue posible agregar la forma de pago, verifica los datos por favor", this, this);

                        CargarFormasPago();
                    }
                }

                else
                {
                    _kernel.MessageBox("Es necesario que proporcione la descripción", this, this);
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxFormasPago.SelectedIndex < 0)
                {
                    _kernel.MessageBox("Seleccione la forma de pago a eliminar", this, this);
                }

                else
                {
                    if (_bridge.BorrarFormaPago(cbxFormasPago.Text))
                    {
                        _kernel.MessageBox("Se borro la forma de pago correctamente", this, this);

                        CargarFormasPago();
                    }

                    else
                    {
                        _kernel.MessageBox("Ocurrió un error y no se pudo eliminar la forma de pago", this, this);

                        CargarFormasPago();
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}