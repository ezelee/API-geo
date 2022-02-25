using MongoDB.Driver;
using mongodb_dotnet_example.Infrastructure;
using mongodb_dotnet_example.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mongodb_dotnet_example.Services
{
    public class GeoService: IGeoService
    {
        private readonly IMongoCollection<Geo> _geo;

        public GeoService(IGeoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _geo = database.GetCollection<Geo>(settings.GeoCollectionName);
        }

        public List<Geo> Get() => _geo.Find(geo => true).ToList();

        public Geo Get(string id) => _geo.Find(geo => geo.Id == id).FirstOrDefault();

        public Geo Create(Geo geo)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var id = new string(Enumerable.Repeat(chars, 24)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            geo.Id = id;
            _geo.InsertOne(geo);
            return geo;
        }

        public void Update(string id, Geo updatedGeo) => _geo.ReplaceOne(geo => geo.Id == id, updatedGeo);

        public void Delete(Geo geoForDeletion) => _geo.DeleteOne(geo => geo.Id == geoForDeletion.Id);

        public void Delete(string id) => _geo.DeleteOne(geo => geo.Id == id);
    }
}