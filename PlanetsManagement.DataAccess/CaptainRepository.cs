using System.Linq;

namespace PlanetsManagement.DataAccess
{
    public class CaptainRepository : BaseRepository
    {
        public Captain GetCaptainByUsername(string captainUsername)
        {
            var captain = DbContext.Captains.FirstOrDefault(c => c.Username == captainUsername);
            return captain;
        }
    }
}
