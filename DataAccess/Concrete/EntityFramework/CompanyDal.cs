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
    public class CompanyDal : BaseEntityRepository<Company, Context>, ICompanyDal
    {
        public List<Company> GetAll(Expression<Func<Company, bool>> filter = null)
        {
            using var context = new Context();
            return filter == null ? context.Set<Company>().ToList() :
                                   context.Set<Company>().Where(filter).ToList();
        }
    }
}
