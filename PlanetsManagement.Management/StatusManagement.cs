using PlanetsManagement.DataAccess;
using PlanetsManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsManagement.Management
{
    public class StatusManagement
    {
        private readonly StatusRepository _repo = new StatusRepository();

        public StatusDTO GetStatusByName(string statusName)
        {
            var repoResult = _repo.GetStatusByName(statusName);
            return new StatusDTO
            {
                id = repoResult.Id,
                name = repoResult.Name
            };
        }

    }
}
