using PlanetManagement.Management;
using PlanetsManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlanetsManagement.Web.Areas_Planets.API.Controllers
{
    [RoutePrefix("api/robots")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RobotController : ApiController
    {
        private RobotManagement _management = new RobotManagement();

        [JwtAuthentication]
        [HttpGet]
        [Route("")]
        public List<RobotDTO> GetRobotsByCaptain(Guid captainId)
        {
            return _management.GetRobotsByCaptain(captainId);
        }
    }
}