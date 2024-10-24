using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EmployeeDal : BaseEntityRepository<Employee, Context>, IEmployeeDal
    {
        public List<EmployeeDetailDto> GetAllEmployeesDetails()
        {
            Context context = new Context();
            var result = from e in context.Employees
                         join d in context.Departments
                         on e.DepartmentId equals d.Id
                         join c in context.Companies
                         on d.CompanyId equals c.Id
                         select new EmployeeDetailDto
                         {
                             Id = e.Id,
                             Name = e.Name,
                             Surname = e.Surname,
                             BirthDate = e.BirthDate,
                             DepartmentName = d.Name,
                             CompanyName = c.Name
                         };
            return result.ToList();
        }

        public EmployeeDetailDto GetEmployeeDetail(Expression<Func<EmployeeDetailDto, bool>> filter)
        {
            var context = new Context();
            var result = from e in context.Employees
                         join d in context.Departments
                         on e.DepartmentId equals d.Id
                         join c in context.Companies
                         on d.CompanyId equals c.Id
                         select new EmployeeDetailDto
                         {
                             Id = e.Id,
                             Name = e.Name,
                             Surname = e.Surname,
                             BirthDate = e.BirthDate,
                             DepartmentName = d.Name,
                             CompanyName = c.Name
                         };
            return result.Where(filter).FirstOrDefault();
        }
    }
}
