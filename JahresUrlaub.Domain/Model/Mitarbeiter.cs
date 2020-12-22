using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Domain.Model
{
    public class Mitarbeiter
    {
		/// <summary>
		/// Employee entity Id.
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Employee entity UserId.
		/// 1:1 relation.
		/// </summary>
		public int PeronalId { get; set; }

		/// <summary>
		/// Employee entity first name.
		/// </summary>
		public string Vorname { get; set; }

		/// <summary>
		/// Employee entity last name.
		/// </summary>
		public string Nachname { get; set; }

		/// <summary>
		/// <see cref="Urlaub/> associated collection.
		/// </summary>
		public IEnumerable<Urlaub> Urlaubs { get; set; }
	}
}
