using System;
using EFCoreMocking.API.Data;
using EFCoreMocking.API.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMocking.API.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
            : base(employeeDbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await FindByCondition(employee => employee.Id.Equals(employeeId))
                .FirstOrDefaultAsync();
        }

        //public async Task<Employee> GetEmployeeWithDetailsAsync(int employeeId)
        //{
        //    return await FindByCondition(employee => employee.Id.Equals(employeeId))
        //        .FirstOrDefaultAsync();
        //}

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}

