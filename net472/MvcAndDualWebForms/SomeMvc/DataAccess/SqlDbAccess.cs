using BuildableMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuildableMvc.DataAccess
{
    public class SqlDbAccess : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}