using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Domain.Model
{
    /// <summary>
	/// Vacation domain model.
	/// </summary>
    public class Urlaub
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int id { get; set; }

        [BsonElement("Personalnummer")]
        public string Personalnummer { get; set; }

        [BsonElement("Nachname")]
        public string Nachname { get; set; }

        [BsonElement("Vorname")]
        public string Vorname { get; set; }

        [BsonElement("DatumVon")]
        public DateTime Datum_Von { get; set; }
        
        [BsonElement("DatumBis")]
        public DateTime Datum_Bis { get; set; }

        [BsonElement("Commentar")]
        public string Commentar { get; set; }
    }
}

