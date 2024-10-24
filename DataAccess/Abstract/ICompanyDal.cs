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
    public interface ICompanyDal:IBaseRepository<Company>
    {
        List<Company> GetAll(Expression<Func<Company, bool>> filter = null);
    }
}
