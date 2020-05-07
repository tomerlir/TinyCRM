using System;
using Microsoft.EntityFrameworkCore;

namespace TinyCRM
{
    public class TinyCrmDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server = localhost; Database = tinycrm; User id = sa; Password = admin!@#123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Customer>()
                .ToTable("Customer");   //Decide the name of the Customer table in the database
        }
    }
}
