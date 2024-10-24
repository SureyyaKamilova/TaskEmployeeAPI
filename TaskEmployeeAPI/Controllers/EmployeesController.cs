using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskEmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployeesDetails")]
        public IActionResult GetAllEmployeesDetails()
        {
            var values = _employeeService.GetAllEmployeesDetails();
            if (values.Count > 0)
            {
                return Ok(values);
            }
            return NotFound("Error");
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeDetail(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _employeeService.Add(employee);
                return Ok("Added employee");
            }

            return BadRequest();

        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (employee.Id != 0)
            {
                _employeeService.Update(employee);
                return Ok("Updated employee");
            }

            return BadRequest();
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.Get(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Record not found.");
            }
            _employeeService.Delete(employee);
            return Ok("Deleted employee");
        }
    }
}
