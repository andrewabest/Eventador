using System;
using System.Collections.Generic;

namespace Eventador.Domain
{
    public class Event : AggregateRoot
    {
        public static Event Create(Guid id, string name, string location)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrWhiteSpace(location)) throw new ArgumentException(nameof(name));

            return new Event
            {
                Id = id,
                Name = name,
                Location = location
            };
        }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public Attendee Register(string firstName, string lastName)
        {
            var attendee = Attendee.Create(Guid.NewGuid(), firstName, lastName, this);

            return attendee;
        }
    }
}