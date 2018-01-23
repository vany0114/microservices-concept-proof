using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi2.Model;

namespace webApi2
{
    public class Api2Repository : IApi2Repository
    {
        private readonly Api2Context _context;

        public Api2Repository(IOptions<Api2Settings> settings)
        {
            _context = new Api2Context(settings);
        }

        public async Task<List<Api2Model>> GetAsync()
        {
            return await _context.Api2Data
                                 .Find(new BsonDocument())
                                 .ToListAsync();
        }

        public async Task AddAsync(Api2Model data)
        {
            await _context.Api2Data.InsertOneAsync(data);
        }
    }

    public interface IApi2Repository
    {
        Task<List<Api2Model>> GetAsync();
        Task AddAsync(Api2Model data);
    }
}
