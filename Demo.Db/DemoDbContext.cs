
using Demo.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace Demo.Db
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext()
            : base("name=main")
        {
            Database.SetInitializer(new DemoDbInitializer());
        }

        public DbSet<Product> ProductSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        }
    }
}
