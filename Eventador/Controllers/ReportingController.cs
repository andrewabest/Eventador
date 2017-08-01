using System;
using System.Threading.Tasks;
using Eventador.Domain;
using Eventador.Repositories;

namespace Eventador.Controllers
{
    public class ReportingController
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public ReportingController(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public Task<Attendee[]> GetCateringReport(Guid eventId)
        {
            return _attendeeRepository.GetAttendeesWithDietaryPreferencesWhoHavePaid(eventId);
        }
    }
}