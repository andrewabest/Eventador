using System;
using System.Collections.Generic;
using System.Data.Entity;
using Eventador.Domain;

namespace Eventador.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
        DbContext Context { get; }

        T Get(Guid id);

        IList<T> GetAll();

        IList<T> FindAll(IDictionary<string, object> propertyValuePairs);

        T FindOne(IDictionary<string, object> propertyValuePairs);

        T SaveOrUpdate(T entity);

        void Delete(T entity);
    }
}