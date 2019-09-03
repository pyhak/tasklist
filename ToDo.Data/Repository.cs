using Microsoft.EntityFrameworkCore;
using Tasklist.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasklist.Data;

namespace Tasklist.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApiContext _context;
        private readonly IUnitOfWork _unitOfWork;
        readonly string errorMessage = string.Empty;

        public Repository(ApiContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifiedOnUtc = DateTime.UtcNow;
            entity.CreatedOnUtc = DateTime.UtcNow;
            _context.Set<T>().Add(entity);
            
        }

        public void Update(T entity)
        {
            entity.ModifiedOnUtc = DateTime.UtcNow;
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<T>().Remove(entity);
            
        }
        
        
    }
}
