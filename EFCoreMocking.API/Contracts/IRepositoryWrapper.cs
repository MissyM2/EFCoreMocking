using System;
namespace EFCoreMocking.API.Repositories
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        Task SaveAsync();
    }
}

