using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_dotnet_example.Models
{
    public class GeoCode
    {
        [BsonId]
        public string Id { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}