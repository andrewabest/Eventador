using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventador.Queries;
using NUnit.Framework;
using Shouldly;

namespace Eventador.Tests
{
    public class EventScenarios
    {
        [Test]
        public async Task RegisterAttendee_HappyPath()
        {
            var @event = Event.Create(Guid.NewGuid(), "Developer Developer Developer", "Melbourne");

            var attendee = @event.Register("Andrew", "Best");

            using (IWriteRepository repository = new EventadorContext())
            {
                repository.Add(@event);

                await repository.Commit();
            }

            IReadRepository readRepository = new EventadorContext();

            (await readRepository.ExistsByIdAsync<Attendee>(attendee.Id)).ShouldBeTrue();
        }
    }

    public class QueryScenarios
    {
        [Test]
        public async Task QuerySqlDump()
        {
            var query = new AttendeesWithDietaryPreferencesWhoHavePaid(new EventadorContext());

            var results = await query.Execute();

            Assert.IsTrue(true);
        }
    }
}