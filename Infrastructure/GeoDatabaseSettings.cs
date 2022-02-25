namespace mongodb_dotnet_example.Infrastructure
{
    public class GeoDatabaseSettings : IGeoDatabaseSettings
    {
        public string GeoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGeoDatabaseSettings
    {
        string GeoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}