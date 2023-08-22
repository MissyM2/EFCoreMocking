using System;
using System.Linq.Expressions;
using EFCoreMocking.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMocking.API.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EmployeeDbContext EmployeeDbContext { get; set; }

        public RepositoryBase(EmployeeDbContext employeeDbContext)
        {
            this.EmployeeDbContext = employeeDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.EmployeeDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.EmployeeDbContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.EmployeeDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.EmployeeDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.EmployeeDbContext.Set<T>().Remove(entity);
        }
    }
}

