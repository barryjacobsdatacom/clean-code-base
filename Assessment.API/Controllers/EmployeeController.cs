using Assessment.Core.Entities;
using Assessment.Core.Repositories;
using Assessment.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
namespace Assessment.Web
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeViewModel employee)
        {
            var employeeEntity = new Employee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email
            };

            _employeeRepository.Add(employeeEntity);
            return this.Ok();
        }

        [HttpPatch("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeViewModel employee)
        {
            var employeeEntity = new Employee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email
            };

            _employeeRepository.Update(employeeEntity);
            return this.Ok();
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeToDelete = _employeeRepository.GetById(id);
            _employeeRepository.Delete(employeeToDelete);
            return this.Ok();
        }

        [HttpGet("GetEmployeesBySurname/{surname}")]
        public IActionResult GetEmployeesBySurname(string surname)
        {
            
            var employeeResult = new List<EmployeeViewModel>();
            var employeesBySurname = _employeeRepository.GetEmployeeBySurname(surname);
            foreach (var employee in employeesBySurname) 
            {
                employeeResult.Add(new EmployeeViewModel
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    DateOfBirth = employee.DateOfBirth,
                    Email = employee.Email
                });
            }

            return this.Ok(employeeResult);
        }
    }
}
