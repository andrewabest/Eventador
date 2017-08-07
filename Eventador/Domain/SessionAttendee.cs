using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventador.Domain
{
    public class SessionAttendee 
    {
        public static SessionAttendee Create(Session session, Attendee attendee)
        {
            return new SessionAttendee {Session_Id = session.Id, Attendee_Id = attendee.Id};
        }

        [Key]
        [Column(Order = 0)]
        public Guid Session_Id { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid Attendee_Id { get; set; }
    }
}