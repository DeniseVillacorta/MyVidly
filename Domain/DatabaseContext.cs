using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Vidly.Models;

namespace Vidly.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=MyVidly;Trusted_Connection=True;")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Customer> Customers { get; set; }
    }
}