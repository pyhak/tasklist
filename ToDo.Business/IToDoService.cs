using System;
using System.Collections.Generic;
using Tasklist.Core.Models;

namespace Tasklist.Business
{
    public interface IToDoService<T> where T : BaseEntity
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Delete(T entity);
        T Edit(T entity);
    }
}