using Assessment.Core.Entities;
using Assessment.Core.Repositories.Base;
using System.Collections.Generic;

namespace Assessment.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeeBySurname(string surname);
    }
}
