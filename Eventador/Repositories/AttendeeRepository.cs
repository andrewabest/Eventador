using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Eventador.Domain;

namespace Eventador.Repositories
{
    public interface IAttendeeRepository : IRepository<Attendee>
    {
        Task<Attendee[]> GetAttendeesWithDietaryPreferencesWhoHavePaid(Guid eventId);
        Task<Attendee[]> GetAttendeesWithSessions(Guid eventId);
    }

    public class AttendeeRepository : EntityFrameworkRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(DbContext context) : base(context)
        {
        }

        public Task<Attendee[]> GetAttendeesWithDietaryPreferencesWhoHavePaid(Guid eventId)
        {
            return Context.Set<Attendee>()
                .Include(x => x.Sessions)
                .Include(x => x.Accommodation)
                .Where(x => x.HasDietaryRequirements)
                .Where(x => x.Sessions.Any(session => session.IsCatered))
                .Where(x => x.Accommodation.All(acc => acc.Amount.Amount != 0))
                .Where(x => x.Event.Id == eventId)
                .ToArrayAsync();
        }

        public Task<Attendee[]> GetAttendeesWithSessions(Guid eventId)
        {
            return Context.Set<Attendee>()
                .Include(x => x.Event)
                .Include(x => x.Sessions)
                .Where(x => x.Event.Id == eventId)
                .ToArrayAsync();
        }
    }
}