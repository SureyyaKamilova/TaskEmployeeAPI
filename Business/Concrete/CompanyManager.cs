﻿using Business.Abstract;
using Core.Business.Concrete;
using Core.Entities.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager:EntityManager<Company>,ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal) : base(companyDal) {
            _companyDal = companyDal;
        }
        public List<Company> GetAll()
        {
            return _companyDal.GetAll();
        }
    }
}
