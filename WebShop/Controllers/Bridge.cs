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
    }
}