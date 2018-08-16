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

        public IEnumerable<Department> Departments()
        {
            using (var context = new SMCContext())
            {
                var res = context.Departments
              .Include("Organization").ToList();
                return res;
            };
        }

        public IEnumerable<Organization> Organizations()
        {
            using (var context = new SMCContext())
            {
                var res = context.Organizations.ToList();
                return res;
            };
        }

        public void EditEmployer(Employee employee)
        {
            using (var context = new SMCContext())
            {
                var emp = context.Employes.Find(employee.EmployeeId);

                Log log = new Log();
                

                if (emp != null)
                {
                    if (emp.FirstName != employee.FirstName)
                    {
                        log.FirstName = emp.FirstName;
                        emp.FirstName = employee.FirstName;
                        
                    }
                    emp.MiddleName = employee.MiddleName;
                    emp.LastName = employee.LastName;
                    emp.Email = employee.Email;
                    emp.Department = context.Departments.Find(keyValues: employee.Department.DepartmentId);
                    if (log != null)
                    {
                        log.dateTime = DateTime.Now;
                        context.Logs.Add(log);
                    }
                    context.SaveChanges();
                }
                else CreateEmployee(employee);
                
            }

        }
        public void CreateEmployee(Employee employee)
        {
            using (var context = new SMCContext())
            {
                var emp = new Employee
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Department = context.Departments.Find(keyValues: employee.Department.DepartmentId)
                };
                context.Employes.Add(emp);
                context.SaveChanges();


            }

        }

        
    }
}
