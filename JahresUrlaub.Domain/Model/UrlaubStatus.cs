using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Domain.Model
{
    public enum UrlaubStatus
    {
		/// <summary>
		/// Submitted vacation status.
		/// </summary>
		Eingereicht,
		/// <summary>
		/// Approved vacation status.
		/// </summary>
		Genehmigt,
		/// <summary>
		/// Rejected vacation status
		/// </summary>
		Abgelehnt,
	}
}
