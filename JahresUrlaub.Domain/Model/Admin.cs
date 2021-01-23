using System;
using System.Collections.Generic;
using System.Text;

namespace Urlaubsverwaltung.Domain.Model
{
    /// <summary>
    /// klass der Geschäftsführer 
    /// </summary>
    public class Admin
    {
        public int Admin_id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string Password { get; set; }
    }
}
