using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Forum.DAL.Domain;

namespace Forum.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T:Entity
    {
        private DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            var tempEntity = _context.Set<T>().Find(entity.Id);
            _context.Set<T>().Remove(tempEntity);
            _context.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Select(p => p);
        }
    }
}
