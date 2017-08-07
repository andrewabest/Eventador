using System;
using System.Collections.Generic;
using System.Data.Entity;
using Eventador.Domain;

namespace Eventador.Repositories
{
    public abstract class EntityFrameworkRepository<T> : IRepository<T> where T : AggregateRoot
    {
        protected EntityFrameworkRepository(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAll(IDictionary<string, object> propertyValuePairs)
        {
            throw new NotImplementedException();
        }

        public T FindOne(IDictionary<string, object> propertyValuePairs)
        {
            throw new NotImplementedException();
        }

        public T SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}