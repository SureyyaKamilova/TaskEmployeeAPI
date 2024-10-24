﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Department:BaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
    }
}