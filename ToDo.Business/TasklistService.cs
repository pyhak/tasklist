using System;
using System.Collections.Generic;
using System.Linq;
using Tasklist.Core.Models;
using Tasklist.Data;

namespace Tasklist.Business
{
    public class TasklistService <T> : ITasklistService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasklistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Repository<T>().Insert(entity);
            _unitOfWork.Save();
            
        }

        public void Delete(T entity)
        {
            _unitOfWork.Repository<T>().Delete(entity);
            _unitOfWork.Save();
        }

        public void Edit(T entity)
        {
            _unitOfWork.Repository<T>().Update(entity);
            _unitOfWork.Save();
        }

        public List<T> GetAll()
        {
            return _unitOfWork.Repository<T>().GetAll().ToList();
        }
        public T GetById(Guid id)
        {
            return _unitOfWork.Repository<T>().Get(id);
        }
    }
}
