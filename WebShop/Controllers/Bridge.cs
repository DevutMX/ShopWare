using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class Bridge
    {
        WebShopModel _model = new WebShopModel();

        public bool AltaCliente(DatosClientes cliente)
        {
            return _model.AltaCliente(cliente);
        }

        public string[] ObtenerAcceso(DatosClientes cliente)
        {
            return _model.ObtenerAcceso(cliente);
        }

        public string AgregarAlCarrito(EnCarrito compra, int idproducto, int usuario)
        {
            return _model.AgregarAlCarrito(compra, idproducto, usuario);
        }

        public bool QuitarDelCarrito(int idproducto, int usuario)
        {
            return _model.QuitarDelCarrito(idproducto, usuario);
        }

        public bool EliminarDelCarrito(int idproducto, int usuario)
        {
            return _model.EliminarDelCarrito(idproducto, usuario);
        }

        public void ObtenerFormasPago(ASPxComboBox aRellenar)
        {
            _model.ObtenerFormasPago(aRellenar);
        }

        public bool BorrarFormaPago(string formaPago)
        {
            return _model.BorrarFormaPago(formaPago);
        }

        public bool VerificarUsoDatosBancarios(string formaPago)
        {
            return _model.VerificarUsoDatosBancarios(formaPago);
        }

        public bool AgregarFormaPago(TiposPago formaPago)
        {
            return _model.AgregarFormaPago(formaPago);
        }

        public decimal ObtenerSaldo(Banco datos)
        {
            return _model.ObtenerSaldo(datos);
        }

        public void ListarClientes(ASPxGridView aRellenar)
        {
            _model.ListarClientes(aRellenar);
        }

        public void ListarUsuarios(ASPxGridView aRellenar)
        {
            _model.ListarUsuarios(aRellenar);
        }

        public void ListarVentas(ASPxGridView aRellenar)
        {
            _model.ListarVentas(aRellenar);
        }

        public void ListarCarrito(ASPxGridView aRellenar, int usuario)
        {
            _model.ListarCarrito(aRellenar, usuario);
        }

        public bool RegistrarVenta(Venta venta)
        {
            return _model.RegistrarVenta(venta);
        }
    }
}