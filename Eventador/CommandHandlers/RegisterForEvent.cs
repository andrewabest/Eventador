using System.Threading.Tasks;
using Eventador.Commands;

namespace Eventador.CommandHandlers
{
    public class RegisterForEvent : IHandle<RegisterForEventCommand>
    {
        private readonly IWriteRepository _writeRepository;

        public RegisterForEvent(IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }
        
        public async Task Handle(RegisterForEventCommand command)
        {
            var @event = await _writeRepository.GetByIdAsync<Event>(command.EventId, x => x.Attendees);

            @event.Register(command.FirstName, command.LastName);

            await _writeRepository.Commit();
        }
    }
}