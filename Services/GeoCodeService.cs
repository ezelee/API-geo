using mongodb_dotnet_example.Dto;
using mongodb_dotnet_example.Infrastructure;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace mongodb_dotnet_example.Services
{
    public class GeoCodeService: IGeoCodeService
    {
        private readonly string _url;
        public virtual HttpClient _httpClient { get; set; }

        public GeoCodeService(IGeoCodeSettings settings)
        {
            _url = settings.url;
            _httpClient = new HttpClient();
        }

        public async Task<GeoCodeDTO> Get(string calle, string altura, string provincia) {
            HttpClient _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.29.0");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            HttpResponseMessage responseHttp = await _httpClient.GetAsync(_url + "q=" + calle + "+" + altura + "+" + provincia + "&format=json&limit=1");
            string result = await responseHttp.Content.ReadAsStringAsync();
            result = result.Substring(1);
            result = result.Substring(0, result.Length - 1);
            GeoCodeDTO geocodificar = JsonConvert.DeserializeObject<GeoCodeDTO>(result);
            return geocodificar;
        }
    }
}