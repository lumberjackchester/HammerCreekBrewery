using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
namespace HammerCreekBrewing.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {


        public Repository(HCBContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        internal HCBContext DbContext { get; set; }
        internal DbSet<T> DbSet { get; set; }


        public virtual HCBContext Context { get { return DbContext; } }
        public virtual DbSet<T> Set { get { return DbSet; } }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeExpressions)
        {

            IQueryable<T> query = this.DbSet;

            foreach (var includeProperty in includeExpressions)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }


        /// <summary>
        /// Add and entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {

            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {

            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }
    }
}
