using Microsoft.AspNetCore.Mvc;
using mongodb_dotnet_example.Models;
using mongodb_dotnet_example.Services;

namespace mongodb_dotnet_example.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeolocalizarController : ControllerBase
    {
        private readonly IGeoService _geoService;

        public GeolocalizarController(IGeoService geoService)
        {
            _geoService = geoService;
        }


        [HttpPost]
        public ActionResult<Geo> Create(GeoPost geopost)
        {
            //implementar Automapper
            Geo geo = new Geo();
            geo.calle = geopost.calle;
            geo.numero = geopost.numero;
            geo.ciudad = geopost.ciudad;
            geo.codigo_postal = geopost.codigo_postal;
            geo.provincia = geopost.provincia;
            geo.pais = geopost.pais;

            _geoService.Create(geo);

            return AcceptedAtAction("AfterCreation", new { id = geo.Id });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<GeoCreated> AfterCreation(string id)
        {
            var geoCreated = new GeoCreated();

            geoCreated.Id = id;

            return geoCreated;
        }
    }
}