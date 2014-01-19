using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HammerCreekBrewing.Data
{
    public interface IRepository<T> where T : class 
    {
        HCBContext Context { get; }
        DbSet<T> Set { get; }            
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

    }
}
