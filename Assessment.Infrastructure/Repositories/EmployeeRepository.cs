using Assessment.Core.Entities;
using Assessment.Core.Repositories;
using Assessment.Infrastructure.Data;
using Assessment.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext) { }
        public IEnumerable<Employee> GetEmployeeBySurname(string surname)
        {
            return _employeeContext.Employees.Where(m => m.Surname == surname).ToList();
        }
    }
}
