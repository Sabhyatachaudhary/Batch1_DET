using Batch1_DET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch1_DET.Data
{
    public class BookContext : DbContext
    {
        public BookContext()
        {

        }
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        //public virtual DbSet<Book> Books { get; set; }
        public  DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=H9BKX52-SHEL;Database=training;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Property Configurations
         //   fluent API

            //modelBuilder.Entity<Book>()
            //    .Property(b => b.price)
            //    .IsRequired()  //[Required]
            //    .HasColumnName("BKprice")
            //    .HasDefaultValue(200);
        }
    }
}
    



