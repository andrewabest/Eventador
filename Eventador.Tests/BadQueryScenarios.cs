using System;
using System.Threading.Tasks;
using Eventador.Repositories;
using NUnit.Framework;

namespace Eventador.Tests
{
    public class BadQueryScenarios
    {
        [Test]
        public async Task QuerySqlDump()
        {
            var repository = new AttendeeRepository(new EventadorContext());

            var results = await repository.GetAttendeesWithDietaryPreferencesWhoHavePaid(Guid.NewGuid());

            Assert.IsTrue(true);
        }
    }
}