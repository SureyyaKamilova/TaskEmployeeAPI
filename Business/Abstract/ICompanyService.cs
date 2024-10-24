﻿using Core.Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService:IEntityService<Company>
    {

        List<Company> GetAll();
    }
}
