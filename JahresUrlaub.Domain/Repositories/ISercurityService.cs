using System;
using System.Collections.Generic;
using System.Text;

namespace Urlaubsverwaltung.Domain.Repositories
{
    /// <summary>
    /// Crypt und Decrpt Schnittstelle 
    /// Verschlüssung von Password beispiel 
    /// </summary>
    interface ISercurityService
    {
        public string Encrypt(string data);
        public string Decrypt(string data);
        public string ComputeHash(string data);
    }
}
