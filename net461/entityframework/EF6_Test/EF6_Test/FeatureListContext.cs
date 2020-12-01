// Tools.DiffFiles D:\Workplace\ASPNETCore-Entity-Framework-6\src\AspnetCoreEF6Example\DataBaseContext.cs D:\Users\louiejon\Desktop\temp\ported.cs
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using AspnetCoreEF6Example.Models;
using System.Data.Entity.ModelConfiguration;

namespace AspnetCoreEF6Example
{
    [DbConfigurationType(typeof (CodeConfig))]
    public class FeatureListContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public FeatureListContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            var context = new DbContext("");
            context.Database.Log = Console.WriteLine;
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

        public void TestMethod()
        {
            ObjectContext test;
            var objectContext = new ObjectContext("");
            objectContext.Translate<MyModel>(null);

            var context = new DataBaseContext("");
            //context.MyModels.Include(model => model.SomeCollection).ThenInclude(anotherModel => anotherModel.SomeProperty));
            context.MyModels.Add(new MyModel());                         // Invocation -> ExpressionStatement
            var newModel = context.MyModels.Add(new MyModel());         // Invocation -> EqualValueClause
            var newModelId = context.MyModels.Add(new MyModel()).Id;// Invocation -> SimpleMemberAccess

            var local = context.MyModels.Local; 
            var count = context.MyModels.Local.Count;

            var queryResult = context.MyModels.SqlQuery("This is my query");
            queryResult.ToString();
            var x = context.Database.Delete().ToString(); 
            context.Database.Delete();

            var y = context.Database.CreateIfNotExists(); 
            context.Database.CreateIfNotExists();

            context.Configuration.ProxyCreationEnabled = true;
            context.Configuration.ProxyCreationEnabled = false;
        }

        public void TestMethod2(DbChangeTracker tracker, DbContextTransaction transaction)
        {
            DbChangeTracker newTracker = null;
            System.Data.Entity.Infrastructure.DbChangeTracker  fullTracker = null;
            DbContextTransaction newTransaction = null;
        }
    }

    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}
