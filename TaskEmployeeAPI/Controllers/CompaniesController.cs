using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskEmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            var values = _companyService.GetAll();
            if (values.Count > 0)
            {
                return Ok(values);
            }
            return NotFound("Error");
        }

        [HttpGet("GetCompany")]
        public IActionResult GetCompany(int id)
        {
            var company = _companyService.Get(e => e.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany(Company company)
        {
            if (company != null)
            {
                _companyService.Add(company);
                return Ok("Added company");
            }

            return BadRequest();

        }

        [HttpPut("UpdateCompany")]
        public IActionResult UpdateCompany(Company company)
        {
            if (company.Id != 0)
            {
                _companyService.Update(company);
                return Ok("Updated company");
            }

            return BadRequest();
        }

        [HttpDelete("DeleteCompany")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _companyService.Get(e => e.Id == id);
            if (company == null)
            {
                return NotFound("Record not found.");
            }
            _companyService.Delete(company);
            return Ok("Deleted company");
        }
    }
}
