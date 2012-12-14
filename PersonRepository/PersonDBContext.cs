using PersonModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRepository
{
    public class PersonDBContext:DbContext, IDisposedTracker
    {
        public DbSet<Person> People { get; set; }

        public bool IsDisposed { get; set; }
        
        public PersonDBContext(): base("ManDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public PersonDBContext(string connectionStringName): base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Man");
            

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }

}
