using PlanetsManagement.DataContracts;
using PlanetsManagement.Web.Areas_Planets.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlanetsManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/planets")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlanetController : ApiController
    {
        private Management.PlanetManagement _management = new Management.PlanetManagement();

        [HttpGet]
        [Route("")]
        public List<PlanetDTO> GetPlanets()
        {
            return _management.GetPlanets();
        }

        [JwtAuthentication]
        [HttpPut]
        [Route("{id}")]
        public PlanetDTO UpdatePlanet([FromBody] PlanetDTO planet)
        {
            return _management.UpdatePlanet(planet);
        }

    }
}
