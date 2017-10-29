using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebShop.Controllers
{
    public class Kernel
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public void MessageBox(string mensaje, Page pagina, Object objeto)
        {
            string contexto = "<SCRIPT language='javascript'>alert('" + mensaje.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = objeto.GetType();
            ClientScriptManager cs = pagina.ClientScript;
            cs.RegisterClientScriptBlock(cstype, contexto, contexto.ToString());
        }
    }
}