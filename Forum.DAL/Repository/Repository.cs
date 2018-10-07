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
        protected DbContext _context;
        public T GetById(long Id)
        {
            var entity = _context.Set<T>().Where(p => p.Id == Id).FirstOrDefault();
            return entity;
        }
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
