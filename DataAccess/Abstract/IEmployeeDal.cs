using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal:IBaseRepository<Employee>
    {
        List<EmployeeDetailDto> GetAllEmployeesDetails();
        EmployeeDetailDto GetEmployeeDetail(Expression<Func<EmployeeDetailDto, bool>> filter);
        List<EmployeeDetailDto> GetEmployeesWithPagination(int pageNumber, int pageSize);

    }
}
