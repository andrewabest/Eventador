using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Eventador.Domain;

namespace Eventador.Queries
{
    public class AttendeesWithDietaryPreferencesWhoHavePaidQuery : IAsyncQuery<AttendeesWithDietaryPreferencesWhoHavePaidResult[]>
    {
        private readonly IReadRepository _readRepository;

        public AttendeesWithDietaryPreferencesWhoHavePaidQuery(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<AttendeesWithDietaryPreferencesWhoHavePaidResult[]> ExecuteAsync()
        {
            return _readRepository.Table<Attendee>(
                    x => x.Sessions,
                    x => x.Accommodation)
                .Where(x => x.HasDietaryRequirements)
                .Where(x => x.Sessions.Any(session => session.IsCatered))
                .Where(x => x.Accommodation.Any(acc => acc.Amount.Amount > 0))
                .Select(x => new AttendeesWithDietaryPreferencesWhoHavePaidResult
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DietaryRequirements = x.DietaryRequirements
                })
                .ToArrayAsync();

        }
    }
    public class AttendeesWithDietaryPreferencesWhoHavePaidResult
    {
        public string DietaryRequirements { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}