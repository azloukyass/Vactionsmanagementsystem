//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminPlatfform.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urlaub
    {
        public int Urlaub_id { get; set; }
        public string Personalnummer { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Nullable<System.DateTime> Datum_Von { get; set; }
        public Nullable<System.DateTime> Datum_Bis { get; set; }
        public string Commentar { get; set; }
        public string UrlaubStatus { get; set; }
    }
}