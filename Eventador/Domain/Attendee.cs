using System;
using System.Collections.Generic;

namespace Eventador.Domain
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
                Event_Id = @event?.Id ?? throw new ArgumentNullException(nameof(@event)),
                FirstName = firstName,
                LastName = lastName
            };
        }

        public Guid Event_Id { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public bool HasDietaryRequirements { get; private set; }

        public string DietaryRequirements { get; private set; }

        public void SpecifyDietaryRequirements(string dietaryRequirements)
        {
            HasDietaryRequirements = true;
            DietaryRequirements = dietaryRequirements;
        }
    }
}