using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Veri tabanı ile ilişki kurmamızı sağlayacak(Proje class ile).
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Db tanımladık
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=True");
        }

        //Db tabloların varlık katmanındaki objeler ile ilişkilendirdik.
        public DbSet<Product> Products { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
