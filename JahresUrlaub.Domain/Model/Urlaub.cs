using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Domain.Model
{
    /// <summary>
	/// Urlaub Domain Model.
	/// </summary>
    public class Urlaub
    {
        public int? id { get; set; }
        public Mitarbeiter Mitarbeiter { get; set;}
        public UrlaubStatus Status { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
    }
}

