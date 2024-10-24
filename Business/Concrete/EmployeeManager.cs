using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager:EntityManager<Employee>,IEmployeeService
    {
        private readonly IEmployeeDal _employeedal;
        public EmployeeManager(IEmployeeDal employeeDal) : base(employeeDal)
        {
            _employeedal = employeeDal;
        }

        public List<EmployeeDetailDto> GetAllEmployeesDetails()
        {
            var result = _employeedal.GetAllEmployeesDetails();
            if (result.Count > 0)
            {
                return result;
            }
            return new List<EmployeeDetailDto>();
        }

        public EmployeeDetailDto GetEmployeeDetail(Expression<Func<EmployeeDetailDto, bool>> filter)
        {
            var employeeDetail = _employeedal.GetEmployeeDetail(filter);
            return employeeDetail;

        }

    }
}
