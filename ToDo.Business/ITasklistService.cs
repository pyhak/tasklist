using System;
using System.Collections.Generic;
using Tasklist.Core.Models;

namespace Tasklist.Business
{
    public interface ITasklistService<T> where T : BaseEntity
    {
        void Add(T entity);
        List<T> GetAll();
        T GetById(Guid id);
        void Delete(T entity);
        void Edit(T entity);
    }
}