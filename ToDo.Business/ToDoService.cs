using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasklist.Core.Models;
using Tasklist.Data;
using Tasklist.Repo;

namespace Tasklist.Business
{
    public class ToDoService <T> : IToDoService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public ToDoService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Insert(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T Edit(T entity)
        {
            return _repository.Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }
        public T GetById(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
