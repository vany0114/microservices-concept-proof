using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi2.Model
{
    public class Api2Model
    {
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<Location> Locations { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
