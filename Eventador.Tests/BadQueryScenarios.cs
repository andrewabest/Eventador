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
            var query = new AttendeesWithDietaryPreferencesWhoHavePaid(new EventadorContext());

            var results = await query.Execute();

            Assert.IsTrue(true);
        }
    }
}