using System;

namespace Eventador.Domain
{
    public class SessionAttendee 
    {
        public static SessionAttendee Create(Session session, Attendee attendee)
        {
            return new SessionAttendee {Session_Id = session.Id, Attendee_Id = attendee.Id};
        }

        public Guid Session_Id { get; set; }
        public Guid Attendee_Id { get; set; }
    }
}