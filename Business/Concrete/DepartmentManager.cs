using Business.Abstract;
using Core.Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmentManager:EntityManager<Department>,IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal) : base(departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

    }
}
