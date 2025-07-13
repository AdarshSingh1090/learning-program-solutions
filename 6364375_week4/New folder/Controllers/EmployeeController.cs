
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("emp")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "IT" },
            new Employee { Id = 2, Name = "Bob", Department = "HR" },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
