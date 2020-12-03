using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration;
using Microsoft.SqlServer.Types;
using EF6Example.Models;

namespace EF6Example
{
    //[DbConfigurationType(typeof (TestConfig))]
    public class TestContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public TestContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            var context = new DbContext("");
            context.Database.Log = Console.WriteLine;
        }

        public void TestMethod()
        {
            var objectContext = new ObjectContext("");
            objectContext.Translate<MyModel>(null);

            var point = SqlGeography.Point(0, 0, 1);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Students");
            });
        }


    }

    public class CustomerConfiguration : EntityTypeConfiguration<MyModel>
    {
        public CustomerConfiguration()
        {
            this.Map(c =>
                {
                    c.Properties(p => new
                    {
                        p.Id,
                        p.Name
                    });
                    c.ToTable("FirstTable");
                })
                .Map(v =>
                {
                    v.Properties(p => new
                    {
                        p.Id
                    });
                    v.ToTable("SecondTable");
                });
        }
    }

    //public class TestConfig : DbConfiguration
    //{
    //    public TestConfig()
    //    {
    //        SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
    //    }
    //}

}
