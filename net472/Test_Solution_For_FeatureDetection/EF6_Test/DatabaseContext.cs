using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EF6Example.Models;

namespace EF6Example
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MyModel> MyModels
        {
            get;
            set;
        }

        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.Log = Console.WriteLine;
            Database.CreateIfNotExists();
        }

        public void TestMethod()
        {
            var context = new DatabaseContext("");

            context.Configuration.ProxyCreationEnabled = true;

            context.MyModels.Add(new MyModel());
            var newModel = context.MyModels.Add(new MyModel());
            var newModelId = context.MyModels.Add(new MyModel()).Id;

            var local = context.MyModels.Local;
            var count = context.MyModels.Local.Count;

            var queryResult = context.MyModels.SqlQuery("This is my query");
        }

        public void Delete()
        {
            Database.Delete();
            MyModels.FirstOrDefault(t => t.Id == 1);
        }

        public void ChangeTrackerTest(DbChangeTracker tracker)
        {
            DbChangeTracker changeTracker = this.ChangeTracker;
            System.Data.Entity.Infrastructure.DbChangeTracker fullyQualifiedChangeTracker = this.ChangeTracker;

            var entries = changeTracker.Entries();
        }

        public void TransactionTest()
        {
            DbContextTransaction newTransaction = Database.BeginTransaction();
            MyModels.Add(new MyModel { Id = 1, Name = "TestTransactionModel" });
            SaveChanges();
            ContinueTransaction(newTransaction);
            newTransaction.Rollback();
        }

        private void ContinueTransaction(DbContextTransaction transaction)
        {
            Database.UseTransaction(transaction.UnderlyingTransaction);
            MyModels.Add(new MyModel { Id = 2, Name = "AnotherTransactionModel" });
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>()
                .HasMany(a => a.Things)
                .WithRequired(t => t.AModel)
                .WillCascadeOnDelete(false);
        }
    }
}
