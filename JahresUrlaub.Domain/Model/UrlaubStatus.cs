using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Domain.Model
{
    public enum UrlaubStatus
    {
		/// <summary>
		/// Noch in Bearbeitung 
		/// </summary>
		Eingereicht,
		/// <summary>
		/// Zusage.
		/// </summary>
		Genehmigt,
		/// <summary>
		/// Absage
		/// </summary>
		Abgelehnt,
	}
}
