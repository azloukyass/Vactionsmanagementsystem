using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JahresUrlaub.Geschäftslogik.Context
{
    public class Settings
    {
        public string ConnectionString;
        public string Database;
        public IConfigurationRoot iconfigurationRoot;
    }
}
