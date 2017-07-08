using System;

namespace Eventador
{
    public class Accommodation : AggregateRoot
    {
        public Accommodation()
        {
            Amount = Money.NullInstance;
        }

        public string Hotel { get; set; }

        public DateTimeOffset From { get; private set; }

        public int Nights { get; private set; }

        public Money Amount { get; private set; }

    }
}