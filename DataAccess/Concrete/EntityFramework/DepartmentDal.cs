using Core.DataAccess.Concrete;
using Core.Entities.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DepartmentDal:BaseEntityRepository<Department,Context>,IDepartmentDal
    {
        public List<Department> GetAll(Expression<Func<Department, bool>> filter = null)
        {
            using var context = new Context();
            return filter == null ? context.Set<Department>().ToList() :
                                   context.Set<Department>().Where(filter).ToList();
        }
    }
}
