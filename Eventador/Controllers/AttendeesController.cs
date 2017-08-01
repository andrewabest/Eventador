using System;
using System.Threading.Tasks;
using Eventador.Domain;
using Eventador.Repositories;

namespace Eventador.Controllers
{
    public class AttendeesController
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public AttendeesController(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public Task<Attendee[]> Get(Guid eventId)
        {
            return _attendeeRepository.GetAttendeesWithSessions(eventId);
        }
    }
}