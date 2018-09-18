using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Forum.DAL.Domain;

namespace Forum.DAL.Repository
{
    public interface IRepository<T> where T: Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
    }
}