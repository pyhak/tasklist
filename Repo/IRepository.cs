using System;
using System.Collections.Generic;
using Tasklist.Core.Models;

namespace Tasklist.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
