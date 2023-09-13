using PlanetsManagement.DataAccess;
using PlanetsManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetManagement.Management
{
    public class RobotManagement
    {
        private RobotRepository _repo = new RobotRepository();

        public RobotDTO GetRobotById(Guid robotId)
        {
            var repoResult = _repo.GetRobotById(robotId);
            return new RobotDTO
            {
                id = repoResult.Id,
                name = repoResult.Name
            };
        }

        public List<RobotDTO> GetRobotsByCaptain(Guid captainId)
        {
            var result = _repo.GetRobotsByCaptain(captainId);

            var toReturn = result.Select(a =>
            new RobotDTO
            {
                id = a.Id,
                name = a.Name,
            }).ToList();

            return toReturn;
        }
    }
}
