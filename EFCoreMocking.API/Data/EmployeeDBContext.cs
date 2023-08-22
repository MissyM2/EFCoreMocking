using System;
using EFCoreMocking.API.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMocking.API.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public EmployeeDbContext()
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 10, Name = "Emp1", Email="emp1@email.com", Phone="301-646-0593" },
                new Employee { Id = 20, Name = "Emp2", Email = "emp2@email.com", Phone = "301-646-0594" },
                new Employee { Id = 30, Name = "Emp3", Email = "emp3@email.com", Phone = "301-666-0593" }
            );
        }
    }

}
