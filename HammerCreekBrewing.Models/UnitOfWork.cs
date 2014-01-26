using System;
using System.Collections.Generic;
using HammerCreekBrewing.Data.Models;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDictionary<Type, object> _repositories;


        public UnitOfWork(HCBContext context)
        {
            DbContext = context;
            SetDbContextProperties();
            _repositories = new Dictionary<Type, object>();
        }


        #region Repositories


        // HammerCreekBrewing repositories
        public IRepository<Beer> Beers { get { return GetRepository<Beer>(); } }
        public IRepository<BeerStyle> BeerStyles { get { return GetRepository<BeerStyle>(); } }
        public IRepository<Brewery> Breweries { get { return GetRepository<Brewery>(); } }
        public IRepository<Location> Locations { get { return GetRepository<Location>(); } }


        #endregion

        // context
        public HCBContext DbContext { get; set; }


        #region Get Repository Methods

        /// <summary>
        /// Get or create-and-cache a repository of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the repository, typically a custom repository interface.
        /// </typeparam>
        /// <remarks>
        /// Looks for the requested repository in its cache, returning if found.
        /// If not found, makes a new one and returns it.
        /// </remarks>
        public virtual IRepository<T> GetRepository<T>() where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            _repositories.TryGetValue(typeof(T), out repoObj);

            if (repoObj != null)
            {
                return repoObj as IRepository<T>;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            var repo = new Repository<T>(this.DbContext);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        #endregion

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            this.DbContext.SaveChanges();
        }
        /// <summary>
        /// Save pending changes asynchronously to the database
        /// </summary>
        public async Task<int> CommitAsync()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
           return await this.DbContext.SaveChangesAsync();
        }

        protected void SetDbContextProperties()
        {

        //    this.DbContext = new HCBContext(System.Configuration.ConfigurationManager.AppSettings["DatabaseContextConnectionName"]);

            // Do NOT enable proxied entities, else serialization fails
            this.DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            this.DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            this.DbContext.Configuration.ValidateOnSaveEnabled = false;

            //   this.DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.

        }

        #region IDisposable


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!disposing) return;

            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }

        #endregion
    }
}
