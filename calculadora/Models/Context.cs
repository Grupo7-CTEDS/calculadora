using System;
using Microsoft.EntityFrameworkCore;

namespace calculadora.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private static Operation[] GetProducts()
        {
            return new Operation[]
            {
            new Operation
            {
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now,
                Text = "((1+2)x(3+2)"
            },


            new Operation
            {
                Id = Guid.NewGuid(),
                Text = "((6/2)+1)",
                CreationTime = DateTime.Now,
            }
            };
        }
    }
}

