namespace mongodb_dotnet_example.Infrastructure
{
    public class GeoCodeSettings : IGeoCodeSettings
    {
        public string url { get; set; }
    }

    public interface IGeoCodeSettings
    {
        string url { get; set; }
    }
}