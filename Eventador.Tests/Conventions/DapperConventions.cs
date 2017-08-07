using System.Linq;
using System.Threading.Tasks;
using Conventional;
using NUnit.Framework;
using Tailor.Test;

namespace Eventador.Tests.Conventions
{
    public class DapperConventions
    {
        [Test]
        public async Task AllQueries_MustSatisfyTheTailor()
        {
            var results = await Task.WhenAll(
                TheTailor
                    .Create(@"Server=(localdb)\MSSQLLocalDB; Database=Eventador.EventadorContext; Integrated Security=True; MultipleActiveResultSets=True",
                        typeof(IAmTheQueryAssembly).Assembly.GetExportedTypes().ToArray())
                    .Measure(typeof(NotFoundException)));

            foreach (var result in results)
            {
                result.WithFailureAssertion(Assert.Fail);
            }
        }
    }
}