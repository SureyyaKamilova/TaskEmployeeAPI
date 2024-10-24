using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDepartmentDal:IBaseRepository<Department>
    {
        List<Department> GetAll(Expression<Func<Department, bool>> filter = null);
    }
}
