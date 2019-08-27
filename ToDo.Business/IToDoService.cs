using System.Collections.Generic;
using ToDo2.Core.Models;

namespace ToDo2.Business
{
    public interface IToDoService<T> where T : BaseEntity
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
        T Edit(T entity);
    }
}