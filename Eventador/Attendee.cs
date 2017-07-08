using System;
using System.Collections.Generic;

namespace Eventador
{
    public class Attendee : AggregateRoot
    {
        public static Attendee Create(Guid id, string firstName, string lastName, Event @event)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException(nameof(lastName));

            return new Attendee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Event = @event ?? throw new ArgumentNullException(nameof(@event))
            };
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string DietaryRequirements { get; private set; }

        // Are these guys hydrated? Are they not? Are you holding EF right?

        public Event Event { get; private set; }

        public ICollection<Session> Sessions { get; } = new List<Session>();

        public ICollection<Accommodation> Accommodation { get; } = new List<Accommodation>();

        public ICollection<Travel> Travel { get; } = new List<Travel>();

        public void SpecifyDietaryRequirements(string dietaryRequirements)
        {
            DietaryRequirements = dietaryRequirements;
        }

        public void Attend(Session session)
        {
            Sessions.Add(session);
            session.Attendees.Add(this);
        }
    }
}