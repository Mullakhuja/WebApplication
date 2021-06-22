using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.DBO;

namespace WebApp.DAL.Repository
{
    public class EmployeeRepo : IRepository<Employee>
    {
        protected readonly PaperCompDbContext _dbContext;

        protected EmployeeRepo(PaperCompDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
