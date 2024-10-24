using Core.Business.Abstract;
using Core.Entities.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService:IEntityService<Employee>
    {
        List<EmployeeDetailDto> GetAllEmployeesDetails();
        EmployeeDetailDto GetEmployeeDetail(Expression<Func<EmployeeDetailDto, bool>> filter);
        List<EmployeeDetailDto> GetEmployeesWithPagination(int pageNumber, int pageSize);
    }
}
