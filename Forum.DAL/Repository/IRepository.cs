using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Forum.DAL.Domain;
using Cross_cutting.Interfaces;

namespace Forum.DAL.Repository
{
    public interface IRepository<T> : IScopedService where T: Entity
    {

        T GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}