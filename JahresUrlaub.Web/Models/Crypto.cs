using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JahresUrlaub.Web.Models
{
    /// <summary>
    /// Verschlüssung von Einträge 
    /// Wurde bei Verschlüssung von Password verwendet
    /// </summary>
    public  static class Crypto
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }
    }
}