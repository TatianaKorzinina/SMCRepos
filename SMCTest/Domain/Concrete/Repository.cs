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

        public IEnumerable<Log> Logs()
        {
            using (var context = new SMCContext())
            {
                var res = context.Logs.Include("LogType").Include("Employee").ToList();
                return res;
            };
        }

        public void EditEmployer(Employee employee)
        {
            using (var context = new SMCContext())
            {
                var emp = context.Employes.
                    Include("Department").Include("Department.Organization").
                    FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                    

                Log log = new Log();
                if (emp == null)
                {
                    CreateEmployee(employee, log);
                }

                if (emp != null)
                {
                    if (emp.FirstName != employee.FirstName)
                    {
                        log.FirstName = emp.FirstName;
                        emp.FirstName = employee.FirstName;
                        
                    }
                    if (emp.MiddleName != employee.MiddleName)
                    {
                        log.MiddleName = emp.MiddleName;
                        emp.MiddleName = employee.MiddleName;
                    }

                    if (emp.LastName != employee.LastName)
                    {
                        log.LastName = emp.LastName;
                        emp.LastName = employee.LastName;
                    }
                    if (emp.Email != employee.Email)
                    {
                        log.Email = emp.Email;
                        emp.Email = employee.Email;
                    }
                    if (emp.Department.DepartmentId != employee.Department.DepartmentId)
                    {
                        log.Department = emp.Department.DepartmentTitle;
                        if (emp.Department.Organization.OrganizationID != employee.Department.
                            Organization.OrganizationID)
                        {
                            log.Organization = emp.Department.Organization.OrganizationTitle;
                        }

                        emp.Department = context.Departments
                            .Find(keyValues: employee.Department.DepartmentId);
                        
                    }
                   
                    if (log.FirstName != null || log.MiddleName != null
                        || log.LastName != null
                        || log.Email != null || 
                        log.Department != null || log.Organization!= null )
                    {
                        log.dateTime = DateTime.Now;
                        log.Employee = emp;
                        log.LogType = context.LogTypes
                            .FirstOrDefault(x=>x.Type=="редактирование данных сотрудника");
                        context.Logs.Add(log);
                    }
                    context.SaveChanges();
                }
                
                
            }

        }
         void CreateEmployee(Employee employee, Log log)
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
                log.FirstName = employee.FirstName;
                log.MiddleName = employee.MiddleName;
                log.LastName = employee.LastName;
                log.Email = employee.Email;
                log.Department = employee.Department.DepartmentTitle;
                log.Organization = employee.Department.Organization.OrganizationTitle;
                log.dateTime = DateTime.Now;
                log.LogType = context.LogTypes.FirstOrDefault(x => x.Type == "добавлен новый сотрудник");
                context.Employes.Add(emp);
                context.Logs.Add(log);
                context.SaveChanges();


            }

        }

        
    }
}
