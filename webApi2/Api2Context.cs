using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi2.Model;

namespace webApi2
{
    public class Api2Context
    {
        private readonly IMongoDatabase _database = null;

        public Api2Context(IOptions<Api2Settings> settings)
        {
            var client = new MongoClient(settings.Value.MongoConnectionString);

            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.MongoDatabase);
            }
        }

        public IMongoCollection<Api2Model> Api2Data
        {
            get
            {
                return _database.GetCollection<Api2Model>("Api2Model");
            }
        }
    }
}
