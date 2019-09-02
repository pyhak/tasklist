using Microsoft.EntityFrameworkCore;
using Tasklist.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasklist.Data;

namespace Tasklist.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly string errorMessage = string.Empty;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }

        public T Get(Guid id)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifiedOnUtc = DateTime.UtcNow;
            entity.CreatedOnUtc = DateTime.UtcNow;
            _unitOfWork.Context.Set<T>().Add(entity);
            
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _unitOfWork.Context.Set<T>().Remove(entity);

        }
    }
}
