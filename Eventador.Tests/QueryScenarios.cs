using System;
using System.Threading.Tasks;
using Eventador.Queries;
using NUnit.Framework;
using Shouldly;
using Tailor;

namespace Eventador.Tests
{
    public class QueryScenarios
    {
        [Test]
        public async Task AttendeeSessionsQuery()
        {
            var query = new AttendeeSessionsQuery(new ConnectionFactory(@"Server=(localdb)\MSSQLLocalDB; Database=Eventador.EventadorContext; Integrated Security=True; MultipleActiveResultSets=True"));

            var result = await query.Execute(new AttendeeSessionsQueryParameters { EventId = Guid.NewGuid() });
            
            result.ShouldBeEmpty();
        }

        [Test]
        public async Task AttendeesWithDietaryPreferencesWhoHavePaidQuery()
        {
            var query = new AttendeesWithDietaryPreferencesWhoHavePaidQuery(new ConnectionFactory(@"Server=(localdb)\MSSQLLocalDB; Database=Eventador.EventadorContext; Integrated Security=True; MultipleActiveResultSets=True"));

            var result = await query.Execute();
            
            result.ShouldBeEmpty();
        }
    }
}