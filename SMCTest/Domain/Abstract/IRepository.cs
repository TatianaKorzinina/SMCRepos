using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<Employee> Employers();
        IEnumerable<Department> Departments();
        IEnumerable<Organization> Organizations();
         void EditEmployer(Employee employee);
    }

    
}
