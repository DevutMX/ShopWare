using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WebShop.Controllers
{
    public class Secret
    {
        public string Cifrar(string original)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(original);
            byte[] hash = sha512.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }
    }
}