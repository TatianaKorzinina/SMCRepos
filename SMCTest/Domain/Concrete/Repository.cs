using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class Repository : IRepository
    {
        public IEnumerable<Employee> Employers()
        {
            
            
               using (var context = new SMCContext())
                    {
                    var res = context.Employes
                   .Include("Department")
                   .Include("Department.Organization").ToList();
                    return res;
                    };
                
            
        }

        public void EditEmployer(Employee employee)
        {
            using (var context = new SMCContext())
            {
                var emp = context.Employes.Find(employee.EmployeeId);
                    
                    
                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.MiddleName = employee.MiddleName;
                    emp.LastName = employee.LastName;
                    emp.Email = employee.Email;
                }
                context.SaveChanges();
            }

        }
    }
}
