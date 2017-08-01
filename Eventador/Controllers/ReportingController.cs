using System;
using System.Threading.Tasks;
using Eventador.Domain;
using Eventador.Queries;

namespace Eventador.Controllers
{
    public class ReportingController
    {
        private readonly AttendeesWithDietaryPreferencesWhoHavePaidQuery _attendeesWithDietaryPreferencesWhoHavePaidQuery;

        public ReportingController(AttendeesWithDietaryPreferencesWhoHavePaidQuery attendeesWithDietaryPreferencesWhoHavePaidQuery)
        {
            _attendeesWithDietaryPreferencesWhoHavePaidQuery = attendeesWithDietaryPreferencesWhoHavePaidQuery;
        }

        public Task<AttendeesWithDietaryPreferencesWhoHavePaidResult[]> GetCateringReport(Guid eventId)
        {
            return _attendeesWithDietaryPreferencesWhoHavePaidQuery.Execute();
        }
    }
}