using Domain;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class RedactorController : Controller
    {
        private IRepository repository;
       

        public RedactorController(IRepository repo)
        {
            repository = repo;
        }
        public ActionResult Edit(int employeeId)
        {
            Employee employee = repository.Employers()
                 .FirstOrDefault(x => x.EmployeeId == employeeId);
            EditEmployersModel editEmployersModel = new EditEmployersModel
            {
                Employee = employee,
                Departments = repository.Departments().ToList(),
                Organizations=repository.Organizations().ToList(), 
        };

          
            return View(editEmployersModel);
        }
        [HttpPost]
        public ActionResult Edit(EditEmployersModel emp)
        {
            var dep = repository.Departments()
            .FirstOrDefault(x => x.DepartmentId == emp.DepId);
            Employee employee = emp.Employee;  
            employee.Department= dep;
            repository.EditEmployer(employee);
            return View("Completed");
            
        }
    }
}