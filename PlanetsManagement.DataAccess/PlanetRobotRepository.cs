using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsManagement.DataAccess
{
    public class PlanetRobotRepository : BaseRepository
    {

        public List<Planets_Robots> GetPlanetsRobots()
        {
            return DbContext.Planets_Robots.ToList();
        }

        public List<Planets_Robots> GetRobotWithPlanetIdFromList(Guid planetId)
        {
            var planetRobots = DbContext.Planets_Robots
                                        .Where(pr => pr.IdPlanet == planetId)
                                        .ToList();

            return planetRobots;
        }

        public void AddPlanetRobot(Planets_Robots newPlanetRobot)
        {
            DbContext.Planets_Robots.Add(newPlanetRobot);
            DbContext.SaveChanges();
        }

        public void DeleteAllPlanetRobotByPlanetId(Guid planeId)
        {
            var planetsRobots = DbContext.Planets_Robots.Where(a => a.IdPlanet == planeId).ToList();

            planetsRobots.ForEach(planetsRobot =>
            {
                if (planetsRobot != null)
                {
                    DbContext.Planets_Robots.Remove(planetsRobot);
                    DbContext.SaveChanges();
                }
            });
        }

    }
}
