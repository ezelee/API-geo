using mongodb_dotnet_example.Models;
using System.Collections.Generic;

namespace mongodb_dotnet_example.Services
{
    public interface IGeoService
    {
        public List<Geo> Get();
        public Geo Get(string id);
        public Geo Create(Geo geo);
        public void Update(string id, Geo updatedGeo);
        public void Delete(Geo geoForDeletion);
        public void Delete(string id);
    }
}