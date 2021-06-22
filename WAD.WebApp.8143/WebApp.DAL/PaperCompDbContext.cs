using Microsoft.EntityFrameworkCore;
using System;
using WebApp.DAL.DBO;

namespace WebApp.DAL
{
    public class PaperCompDbContext : DbContext
    {
        public PaperCompDbContext(DbContextOptions<PaperCompDbContext> options) : base(options)
        {
            Database.EnsureCreatedAsync();
        }
        
        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<Branch> Branch { get; set; }
    }
}
