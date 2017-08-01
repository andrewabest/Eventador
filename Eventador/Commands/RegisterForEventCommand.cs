using System;
using System.Threading.Tasks;
using Eventador.Domain;

namespace Eventador.Commands
{
    public class RegisterForEventCommandHandler : IHandle<RegisterForEventCommand>
    {
        private readonly IWriteRepository _writeRepository;

        public RegisterForEventCommandHandler(IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(RegisterForEventCommand command)
        {
            var @event = await _writeRepository.GetByIdAsync<Event>(command.EventId);

            var attendee = @event.Register(command.FirstName, command.LastName);

            _writeRepository.Add(attendee);

            await _writeRepository.Commit();
        }
    }

    public class RegisterForEventCommand : IDomainCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid EventId { get; set; }
    }
}