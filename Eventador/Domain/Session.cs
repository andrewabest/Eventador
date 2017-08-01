using System;
using System.Collections.Generic;

namespace Eventador.Domain
{
    public class Session : AggregateRoot
    {
        public static Session Create(Guid id, string title, string presenter, DateTimeOffset startsAt, TimeSpan duration, bool isCatered)
        {
            return new Session 
            {
                Id = id,
                Title = title,
                Presenter = presenter,
                StartsAt = startsAt,
                Duration = duration,
                IsCatered = isCatered
            };
        }

        public string Title { get; private set; }

        public string Presenter { get; private set; }

        public DateTimeOffset StartsAt { get; private set; }

        public TimeSpan Duration { get; private set; }

        public bool IsCatered { get; private set; }

        public SessionAttendee Register(Attendee attendee)
        {
            return SessionAttendee.Create(this, attendee);
        }
    }
}