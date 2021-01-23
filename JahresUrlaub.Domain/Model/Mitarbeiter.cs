using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Domain.Model
{
	/// <summary>
	/// Klass der Mitarbeiter mit alle Eigenschaften 
	/// </summary>
    public class Mitarbeiter
    {
		public int Peronaalnummer { get; set; }
		public string Vorname { get; set; }
		public string Nachname { get; set; }
		/// <summary>
		/// <see cref="Urlaub/> associated collection.
		/// </summary>
		public IEnumerable<Urlaub> Urlaubs { get; set; }
		public string Password { get; set; }
	}
}
