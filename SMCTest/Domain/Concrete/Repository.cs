﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class Repository : IRepository
    {
        public IEnumerable<Employee> Employers
        {
            get
            {
                var context = new SMCContext();
                    {
                    var res = context.Employes
                   .Include("Department")
                   .Include("Department.Organization");
                    return res;
                    };
                
            }
        }
    }
}