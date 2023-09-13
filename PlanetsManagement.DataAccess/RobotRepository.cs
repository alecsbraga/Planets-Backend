using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetsManagement.DataAccess
{
    public class RobotRepository : BaseRepository
    {
        public Robot GetRobotById(Guid idRobot)
        {
            var robot = DbContext.Robots.FirstOrDefault(s => s.Id == idRobot);
            return robot;
        }

        public List<Robot> GetRobotsByCaptain(Guid captainId)
        {
            return DbContext.Robots.Where(r => r.IdCaptain == captainId).ToList();
        }
    }
}
