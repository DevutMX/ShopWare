using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Controllers
{
    public class Banco
    {
        public long Tarjeta { get; set; }
        public Decimal Saldo { get; set; }
    }

    public class TiposPago
    {
        public int Tipo { get; private set; }
        public string Descripcion { get; set; }
        public int RequiereTarjeta { get; set; }
    }

    public class Empresa
    {
        public int Id { get; private set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public long Tarjeta { get; set; }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public int Existencias { get; set; }
        public int Categoria { get; set; }
    }

    public class DatosClientes
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public long Tarjeta { get; set; }
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public short CVV { get; set; }
    }

    public class Carrito
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public string Ticket { get; set; }
        public int Cliente { get; set; }
    }

    public class Venta
    {
        public string Ticket { get; set; }
        public decimal Total { get; set; }
        public int TipoPago { get; set; }
        public int Cliente { get; set; }
    }
}