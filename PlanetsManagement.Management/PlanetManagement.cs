using PlanetManagement.Management;
using PlanetsManagement.DataAccess;
using PlanetsManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetsManagement.Management
{
    public class PlanetManagement
    {
        private PlanetRepository _repoPlanet = new PlanetRepository();
        private RobotManagement _manegementRobot = new RobotManagement();
        private PlanetRobotRepository _repoPlanetRobot = new PlanetRobotRepository();
        private StatusManagement _statusManagement = new StatusManagement();


        public List<PlanetDTO> GetPlanets()
        {
            var result = _repoPlanet.GetPlanets();

            var toReturn = result.Select(a =>
            new PlanetDTO
            {
                id = a.Id,
                name = a.Name,
                status = a.Status.Name,
                description = a.Description,
                lastCaptainUpdate = a.LastCaptainUpdate,
                image = a.Image,
                robots = _repoPlanetRobot.GetRobotWithPlanetIdFromList(a.Id)
                        .Select(planetRobot =>
                        {
                            var robot = _manegementRobot.GetRobotById(planetRobot.IdRobot);
                            var robotDTO = new RobotDTO
                            {
                                id = robot.id,
                                name = robot.name,
                            };
                            return robotDTO;
                        }).ToArray()
            }).ToList();

            return toReturn;
        }


        public PlanetDTO GetPlanet(Guid id)
        {
            var repoResult = _repoPlanet.GetPlanet(id);
            return new PlanetDTO
            {
                id = repoResult.Id,
                name = repoResult.Name,
                status = repoResult.Status.Name,
                description = repoResult.Description,
                lastCaptainUpdate = repoResult.LastCaptainUpdate,
                image = repoResult.Image,
                robots = _repoPlanetRobot.GetRobotWithPlanetIdFromList(repoResult.Id)
                        .Select(planetRobot =>
                        {
                            var robot = _manegementRobot.GetRobotById(planetRobot.IdRobot);
                            var robotDTO = new RobotDTO
                            {
                                id = robot.id,
                                name = robot.name,
                            };
                            return robotDTO;
                        }).ToArray()
            };
        }

        public PlanetDTO UpdatePlanet(PlanetDTO planet)
        {
            var planetUpdate = new Planet
            {
                Id = planet.id,
                Name = planet.name,
                Description = planet.description,
                Image = planet.image,
                LastCaptainUpdate = planet.lastCaptainUpdate,
                StatusId = _statusManagement.GetStatusByName(planet.status).id
            };

            _repoPlanetRobot.DeleteAllPlanetRobotByPlanetId(planet.id);

            foreach (var robot in planet.robots)
            {
                var robotUpdate = new Planets_Robots
                {
                    Id= Guid.NewGuid(),
                    IdPlanet = planet.id,
                    IdRobot = robot.id,
                };
                _repoPlanetRobot.AddPlanetRobot(robotUpdate);
            }
            

            _repoPlanet.UpdatePlanet(planetUpdate);
            return GetPlanet(planet.id);
        }
    }
}
