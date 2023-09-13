using System.Linq;

namespace PlanetsManagement.DataAccess
{
    public class StatusRepository : BaseRepository
    {
        public Status GetStatusByName(string statusName)
        {
            var status = DbContext.Status.FirstOrDefault(s => s.Name == statusName);
            return status;
        }
    }
}
