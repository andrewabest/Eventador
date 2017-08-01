using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Eventador.Domain;

namespace Eventador.Queries
{
    public class AttendeeSessionsQuery : IAsyncQuery<AttendeeSessionsQueryParameters, AttendeeSessionsQueryResult[]>
    {
        private readonly IReadRepository _readRepository;

        public AttendeeSessionsQuery(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<AttendeeSessionsQueryResult[]> ExecuteAsync(AttendeeSessionsQueryParameters parameters)
        {
            return _readRepository.Table<Attendee>(x => x.Event, x => x.Sessions)
                .Where(x => x.Event.Id == parameters.EventId)
                .Select(x => new AttendeeSessionsQueryResult
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Sessions = x.Sessions.Select(s => new AttendeeSessionsQueryResult.SessionDto
                    {
                        Id = s.Id,
                        Title = s.Title,
                        Presenter = s.Presenter,
                        StartsAt = s.StartsAt,
                        IsCatered = s.IsCatered
                    })
                })
                .ToArrayAsync();
        }
    }

    public class AttendeeSessionsQueryParameters
    {
        public Guid EventId { get; set; }
    }

    public class AttendeeSessionsQueryResult
    {

        public class SessionDto
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Presenter { get; set; }
            public DateTimeOffset StartsAt { get; set; }
            public bool IsCatered { get; set; }
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<SessionDto> Sessions { get; set; }
    }
}