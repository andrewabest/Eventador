using System;
using System.Threading.Tasks;
using Eventador.Domain;
using Eventador.Queries;

namespace Eventador.Controllers
{
    public class AttendeesController
    {
        private readonly AttendeeSessionsQuery _attendeeSessionsQuery;

        public AttendeesController(AttendeeSessionsQuery attendeeSessionsQuery)
        {
            _attendeeSessionsQuery = attendeeSessionsQuery;
        }

        public Task<AttendeeSessionsQueryResult[]> GetWithSessions(AttendeeSessionsQueryParameters parameters)
        {
            return _attendeeSessionsQuery.Execute(parameters);
        }
    }
}