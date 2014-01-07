using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using HammerCreekBrewing.Domain;
namespace Repository
{


    public class RepositoryContext : DbContext, IUnitOfWork
    {

        // ToDo: Move Initializer to Global.asax; don't want dependence on SampleData
        static RepositoryContext()
        {
           // Database.SetInitializer(new DatabaseInitializer());
        }

        public RepositoryContext()
            : base(nameOrConnectionString: "Repository")
        {

            Debug.Print("New Respository Context");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IDbSet<Beer> Beers { get; set; }
        public IDbSet<Style> Styles { get; set; } 
    }
}