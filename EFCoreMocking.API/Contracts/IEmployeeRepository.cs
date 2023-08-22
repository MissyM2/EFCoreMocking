using System;
using EFCoreMocking.API.Entities.Models;

namespace EFCoreMocking.API.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        //Task<Employee> GetEmployeeWithDetailsAsync(int employeeId);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}

