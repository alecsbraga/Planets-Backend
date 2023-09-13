using PlanetsManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlanetsManagement.Web.Areas_Planets.API.Controllers
{
    [RoutePrefix("api/captain")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CaptainController : ApiController
    {
        private Management.CaptainManagement _captainManagement = new Management.CaptainManagement();

        [HttpPost]
        [Route("login")]
        public ResponseDTO LoginCaptain([FromBody] CaptainDTO captain)
        {
            return _captainManagement.CheckPassword(captain);
        }
    }
}