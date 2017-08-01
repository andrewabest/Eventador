using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Eventador.Domain;
using Tailor;

namespace Eventador.Queries
{
    public class AttendeeSessionsQuery : AsyncDapperQuery<AttendeeSessionsQueryParameters, AttendeeSessionsQueryResult[]>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AttendeeSessionsQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public override async Task<AttendeeSessionsQueryResult[]> Execute(AttendeeSessionsQueryParameters parameters)
        {
            using (var connection = _connectionFactory.Connection)
            {
                return (
                    await connection.QueryAsync<AttendeeSessionsQueryResult, AttendeeSessionsQueryResult.SessionDto, AttendeeSessionsQueryResult>(
                        GetSql(), 
                        (attendee, session) => 
                        {
                            attendee.Sessions.Add(session);
                            return attendee;
                        },
                        parameters.ToDapperParameters())).ToArray();
            }
        }

        public override string GetSql()
        {
            return @"Select Attendees.Id, FirstName, LastName, Sessions.Id, Title, Presenter, StartsAt, IsCatered
                     From Attendees 
                        Left Outer Join SessionAttendees on Attendees.Id = SessionAttendees.Attendee_Id
                        Left Outer Join Sessions on SessionAttendees.Session_Id = Sessions.Id
                   ";
        }
    }

    public class AttendeeSessionsQueryParameters : IQueryParameters
    {
        public Guid EventId { get; set; }
    }

    public class AttendeeSessionsQueryResult
    {
        public AttendeeSessionsQueryResult()
        {
            Sessions = new List<SessionDto>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<SessionDto> Sessions { get; set; }

        public class SessionDto
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Presenter { get; set; }
            public DateTimeOffset StartsAt { get; set; }
            public bool IsCatered { get; set; }
        }
    }
}