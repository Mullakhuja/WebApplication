using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.DBO;

namespace WebApp.DAL.Repository
{
    public class BranchRepo : IRepository<Branch>
    {
        protected readonly PaperCompDbContext _dbContext;

        protected BranchRepo(PaperCompDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Branch branch)
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

        public Task<List<Branch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Branch> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Branch branch)
        {
            throw new NotImplementedException();
        }
    }
}
