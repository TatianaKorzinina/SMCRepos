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

        public ActionResult Edit(int employeeId=0)
        {
            Employee employee=null;
            if (employeeId != 0)
            {
                employee = repository.Employers()
                .FirstOrDefault(x => x.EmployeeId == employeeId);

                if (employee == null) { return View("EditError"); }

                ViewBag.Org = repository.Organizations();
                ViewBag.Dep = repository.Departments()
                    .Where(x => x.Organization.OrganizationID == employee.Department.Organization.OrganizationID);
            }
            else
            {
                ViewBag.Org = repository.Organizations();
                ViewBag.Dep = repository.Departments();
            }
            return View(employee);
        }

        public ActionResult GetDepartments(int orgId)
        {
            var res = repository.Departments()
                .Where(x => x.Organization.OrganizationID == orgId)
                .ToList();
            return PartialView(res);
        }


        [HttpPost]
        public ActionResult Edit(Employee emp)
        {

            var dep = repository.Departments()
            .FirstOrDefault(x => x.DepartmentId == emp.Department.DepartmentId); 
            emp.Department= dep;
            
            repository.EditEmployer(emp);
            return View("Completed");
            
        }
    }
}