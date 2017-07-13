using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Eventador.Repositories
{
    public interface IAttendeeRepository : IRepository<Attendee>
    {
        Task<Attendee[]> GetAttendeesWithDietaryPreferencesWhoHavePaid();
    }

    public class AttendeeRepository : EntityFrameworkRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(DbContext context) : base(context)
        {
        }

        public Task<Attendee[]> GetAttendeesWithDietaryPreferencesWhoHavePaid()
        {
            return Context.Set<Attendee>()
                .Include(x => x.Sessions)
                .Include(x => x.Accommodation)
                .Where(x => x.HasDietaryRequirements)
                .Where(x => x.Sessions.Any(session => session.IsCatered))
                .Where(x => x.Accommodation.All(acc => acc.Amount.Amount != 0))
                .ToArrayAsync();
        }
    }
}