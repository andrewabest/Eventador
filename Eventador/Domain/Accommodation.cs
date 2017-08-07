using System;

namespace Eventador.Domain
{
    public class Accommodation : AggregateRoot
    {
        public Accommodation()
        {
            Amount = Money.NullInstance;
        }

        public Guid Attendee_ID { get; set; }

        public string Hotel { get; set; }

        public DateTimeOffset From { get; private set; }

        public int Nights { get; private set; }

        public Money Amount { get; private set; }
    }
}