using System;
using System.Threading.Tasks;
using Eventador.Queries;
using NUnit.Framework;

namespace Eventador.Tests
{
    public class BadQueryScenarios
    {
        [Test]
        public async Task QuerySqlDump()
        {
            var query = new AttendeesWithDietaryPreferencesWhoHavePaidQuery(new EventadorContext());

            var results = await query.ExecuteAsync();

            Assert.IsTrue(true);
        }
    }
}