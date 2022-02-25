using mongodb_dotnet_example.Dto;
using System.Threading.Tasks;

namespace mongodb_dotnet_example.Services
{
    public interface IGeoCodeService
    {
        public Task<GeoCodeDTO> Get(string calle, string altura, string provincia);
    }
}