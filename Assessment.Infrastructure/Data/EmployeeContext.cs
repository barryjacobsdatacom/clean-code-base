using Assessment.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Employee> Employees
        {
            get;
            set;
        }
    }
}
