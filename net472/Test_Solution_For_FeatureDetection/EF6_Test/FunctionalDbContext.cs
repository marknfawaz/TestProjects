using System.Data.Entity;
using EF6Example.Models;

namespace EF6Example
{
    public class FunctionalDbContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public FunctionalDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        public void Method(DbContextTransaction trx)
        {
            DbContextTransaction trx2 = null;
        }
    }
}
