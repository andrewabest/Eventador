using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Eventador.Queries
{
    public class AttendeesWithDietaryPreferencesWhoHavePaid
    {
        private readonly IReadRepository _readRepository;

        public AttendeesWithDietaryPreferencesWhoHavePaid(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<AttendeeDto[]> Execute()
        {
            return _readRepository.Table<Attendee>(
                    x => x.Sessions,
                    x => x.Accommodation)
                .Where(x => x.HasDietaryRequirements)
                .Where(x => x.Sessions.Any(session => session.IsCatered))
                .Where(x => x.Accommodation.Any(acc => acc.Amount.Amount > 0))
                .Select(x => new AttendeeDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DietaryRequirements = x.DietaryRequirements
                })
                .ToArrayAsync();

        }
    }
}
