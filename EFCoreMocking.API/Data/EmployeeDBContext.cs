using System;
using EFCoreMocking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMocking.API.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public EmployeeDBContext()
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = default!;
    }

}
