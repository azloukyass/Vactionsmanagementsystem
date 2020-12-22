using JahresUrlaub.Domain.Model;
using JahresUrlaub.Geschäftslogik.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Repository.Context
{
    /// <summary>
	/// Main database context of application.
	/// Connection string is configured in appsettings.json under "ConnectionStrings:DefaultConnection" key
	/// </summary>
   public class ApplicationContext 
    {
        public IConfigurationRoot configuration { get; }
        private IMongoDatabase _database = null; 

        public ApplicationContext(IOptions<Settings> settings)
        {
            configuration = settings.Value.iconfigurationRoot;
            settings.Value.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString); 
            if(client!= null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
        public IMongoCollection<Urlaub> Urlaubs
        {
            get
            {
                return _database.GetCollection<Urlaub>("Urlaub"); 
            }
        }
    }
}
