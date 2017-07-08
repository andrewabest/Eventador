using System;

namespace Eventador.Commands
{
    public class RegisterForEventCommand : IDomainCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid EventId { get; set; }
    }
}