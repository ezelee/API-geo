using Microsoft.AspNetCore.Mvc;
using mongodb_dotnet_example.Dto;
using mongodb_dotnet_example.Models;
using mongodb_dotnet_example.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace mongodb_dotnet_example.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeoCodificarController : ControllerBase
    {
        private readonly IGeoService _geoService;
        private readonly IGeoCodeService _geocodeService;

        public GeoCodificarController(IGeoService geoService, IGeoCodeService geoCodeService)
        {
            _geoService = geoService;
            _geocodeService = geoCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<GeoCode>> GeoCodificarAsync([FromQuery] string id)
        {
            var geo = _geoService.Get(id);

            if (geo == null)
            {
                return NotFound();
            }

            var geoCode = new GeoCode();
            geoCode.Id = geo.Id;

            var geocodificar = await _geocodeService.Get(geo.calle, geo.numero, geo.provincia);

            geoCode.latitud = geocodificar.lat;
            geoCode.longitud = geocodificar.lon;

            return geoCode;
        }
    }
}