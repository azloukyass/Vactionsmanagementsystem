//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JahresUrlaub.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Events
    {
        public int EventID { get; set; }
        [Required(ErrorMessage = "Das Feld ist Erfolgreich")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Das Feld ist Erfolgreich")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Das Feld ist Erfolgreich")]
        public Nullable<System.DateTime> Start { get; set; }
        [Required(ErrorMessage = "Das Feld ist Erfolgreich")]
        public string ThemeColor { get; set; }
        [Required(ErrorMessage = "Das Feld ist Erfolgreich")]
        public Nullable<System.DateTime> End { get; set; }
    }
}
