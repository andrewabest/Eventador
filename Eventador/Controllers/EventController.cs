using System;
using System.Threading.Tasks;
using Eventador.Commands;
using Eventador.Domain;

namespace Eventador.Controllers
{
    public class EventController
    {
        private readonly RegisterForEventCommandHandler _registerForEventCommandHandler;

        public EventController(RegisterForEventCommandHandler registerForEventCommandHandler)
        {
            _registerForEventCommandHandler= registerForEventCommandHandler;
        }

        public Task Register(RegisterForEventCommand registerForEventCommand)
        {
            return _registerForEventCommandHandler.Handle(registerForEventCommand);
        }
    }
}