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
        private readonly ApiContext _context;
        private readonly DbSet<T> entities;
        readonly string errorMessage = string.Empty;

        public Repository(ApiContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifiedOnUtc = DateTime.UtcNow;
            entity.CreatedOnUtc = DateTime.UtcNow;
            entities.Add(entity);
            
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
            entities.Remove(entity);
            
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
