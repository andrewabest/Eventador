using System;
using System.Threading.Tasks;
using Eventador.Domain;
using Eventador.Repositories;

namespace Eventador.Controllers
{
    public class EventController
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Attendee Register(Guid eventId, string firstName, string lastName)
        {
            var @event = _eventRepository.Get(eventId);

            return @event.Register(firstName, lastName);

            // NOTE: Assumes transient UoW
        }
    }
}