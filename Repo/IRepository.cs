using System;
using System.Collections.Generic;
using Tasklist.Core.Models;

namespace Tasklist.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
