using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsManagement.DataContracts
{
    public class PlanetDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string image { get; set; }
        public string lastCaptainUpdate { get; set; }
        public RobotDTO[] robots { get; set; }
        public Guid id { get; set; }
    }
}
