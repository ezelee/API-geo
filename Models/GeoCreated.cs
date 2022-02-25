using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_dotnet_example.Models
{
    public class GeoCreated
    {
        [BsonId]
        public string Id { get; set; }
    }
}