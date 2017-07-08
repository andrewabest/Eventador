using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eventador
{
    public interface IWriteRepository : IDisposable
    {
        IQueryable<T> Table<T>(params Expression<Func<T, object>>[] includes) where T : AggregateRoot;
        bool ExistsById<T>(Guid id) where T : AggregateRoot;
        Task<bool> ExistsByIdAsync<T>(Guid id) where T : AggregateRoot;
        Task<T> GetByIdAsync<T>(Guid id, params Expression<Func<T, object>>[] includes) where T : AggregateRoot;
        Task<T> FindAsync<T>(Guid id) where T : AggregateRoot;
        void Add<T>(T aggregateRoot) where T : AggregateRoot;
        void Remove<T>(T aggregateRoot) where T : class;
        Task<int> Commit();
    }

    public interface IReadRepository
    {
        IQueryable<T> Table<T>(params Expression<Func<T, object>>[] includes) where T : AggregateRoot;
        Task<bool> ExistsByIdAsync<T>(Guid id) where T : AggregateRoot;
        Task<T> GetById<T>(Guid id, params Expression<Func<T, object>>[] includes) where T : AggregateRoot;
        Task<T> GetByIdAsync<T>(Guid id, params Expression<Func<T, object>>[] includes) where T : AggregateRoot;
    }

    public partial class EventadorContext : IWriteRepository, IReadRepository
    {
        public Task<int> Commit()
        {
            return SaveChangesAsync();
        }


        public IQueryable<T> Table<T>(params Expression<Func<T, object>>[] includes) where T : AggregateRoot
        {
            var set = Set<T>().AsQueryable();

            set = includes.Aggregate(set, (current, include) => current.Include(include));

            return set;
        }

        public bool ExistsById<T>(Guid id) where T : AggregateRoot
        {
            return Set<T>().Any(x => x.Id == id);
        }

        public Task<bool> ExistsByIdAsync<T>(Guid id) where T : AggregateRoot
        {
            return Set<T>().AnyAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync<T>(Guid id, params Expression<Func<T, object>>[] includes) where T : AggregateRoot
        {
            var result = await GetByIdOrNullAsync(id, includes);

            if (result == null)
                throw new NotFoundException($"The AggregateRoot of type {typeof(T).Name} with the given Id {id} cannot be found.");

            return result;
        }

        private async Task<T> GetByIdOrNullAsync<T>(Guid id, Expression<Func<T, object>>[] includes) where T : AggregateRoot
        {
            var set = Set<T>().AsQueryable();

            set = includes.Aggregate(set, (current, include) => current.Include<T, object>(include));

            return await set.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> FindAsync<T>(Guid id) where T : AggregateRoot
        {
            var result = await Set<T>().FindAsync(id);

            if (result == null)
                throw new NotFoundException($"The AggregateRoot of type {typeof(T).Name} with the given Id {id} cannot be found.");

            return result;
        }

        public new void Add<T>(T aggregateRoot) where T : AggregateRoot
        {
            Set<T>().Add(aggregateRoot);
        }

        public new void Remove<T>(T aggregateRoot) where T : class
        {
            Set<T>().Remove(aggregateRoot);
        }

        IQueryable<T> IReadRepository.Table<T>(params Expression<Func<T, object>>[] includes)
        {
            var set = Set<T>().AsQueryable();

            set = includes.Aggregate(set, (current, include) => current.Include(include));

            return set.AsNoTracking();
        }

        async Task<T> IReadRepository.GetById<T>(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var set = Set<T>().AsNoTracking().AsQueryable();

            set = includes.Aggregate(set, (current, include) => current.Include(include));

            var result = await set.SingleOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException($"The AggregateRoot of type {typeof(T).Name} with the given Id {id} cannot be found.");

            return result;
        }
    }
}