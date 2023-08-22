using EFCoreMocking.API.Data;

namespace EFCoreMocking.API.Repositories

{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EmployeeDbContext _employeeDbContext;
        private IEmployeeRepository _employee;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_employeeDbContext);
                }

                return _employee;
            }
        }

        public RepositoryWrapper(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task SaveAsync()
        {
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}


