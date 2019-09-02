using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasklist.Core.Models;
using Tasklist.Data;
using Tasklist.Repo;

namespace Tasklist.Business
{
    public class TasklistService <T> : ITasklistService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<T> _repository;

        public TasklistService(IUnitOfWork uow, IRepository<T> repository)
        {
            _repository = repository;
            _uow = uow;
        }
        public void Add(T entity)
        {
            _repository.Insert(entity);
            _uow.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _uow.Commit();
        }

        public void Edit(T entity)
        {
            _repository.Update(entity);
            _uow.Commit();
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
