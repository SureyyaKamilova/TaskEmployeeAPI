using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskEmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var values = _departmentService.GetAll();
            if (values.Count > 0)
            {
                return Ok(values);
            }
            return NotFound("Error");
        }

        [HttpGet("GetDepartment")]
        public IActionResult GetDepartment(int id)
        {
            var department = _departmentService.Get(e => e.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            if (department != null)
            {
                _departmentService.Add(department);
                return Ok("Added department");
            }

            return BadRequest();

        }

        [HttpPut("UpdateDepartment")]
        public IActionResult UpdateDepartment(Department department)
        {
            if (department.Id != 0)
            {
                _departmentService.Update(department);
                return Ok("Updated department");
            }

            return BadRequest();
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _departmentService.Get(e => e.Id == id);
            if (department == null)
            {
                return NotFound("Record not found.");
            }
            _departmentService.Delete(department);
            return Ok("Deleted department");
        }
    }
}
