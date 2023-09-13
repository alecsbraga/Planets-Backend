using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsManagement.DataAccess
{
    public class PlanetRepository : BaseRepository
    {

        public List<Planet> GetPlanets()
        {
            return DbContext.Planets.ToList();
        }

        public Planet GetPlanet(Guid planetId)
        {
            var planet = DbContext.Planets.FirstOrDefault(p => p.Id == planetId);
            return planet;
        }

        public void UpdatePlanet(Planet updatedPlanet)
        {
            var existingPlanet = DbContext.Planets.FirstOrDefault(a => a.Id == updatedPlanet.Id);

            existingPlanet.Name = updatedPlanet.Name == null ? existingPlanet.Name : updatedPlanet.Name;
            existingPlanet.Image = updatedPlanet.Image == null ? existingPlanet.Image : updatedPlanet.Image;
            existingPlanet.Description = updatedPlanet.Description;
            existingPlanet.LastCaptainUpdate = updatedPlanet.LastCaptainUpdate;
            existingPlanet.StatusId = updatedPlanet.StatusId;
            DbContext.SaveChanges();
        }
    }
}
