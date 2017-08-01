using System.Data.Entity;
using Eventador.Domain;

namespace Eventador.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
    }

    public class EventRepository : EntityFrameworkRepository<Event>
    {
        public EventRepository(DbContext context) : base(context)
        {
        }
    }
}