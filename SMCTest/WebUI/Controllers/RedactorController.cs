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
        //    EditEmployersModel editEmployersModel = new EditEmployersModel
        //    {
        //        Employee = employee,
        //        Departments = repository.Departments().ToList(),
        //        Organizations=repository.Organizations().ToList(), 
        //};

            ViewBag.Org=repository.Organizations();
            ViewBag.Dep = repository.Departments()
                .Where(x=>x.Organization.OrganizationID==employee.Department.Organization.OrganizationID);
            ViewBag.OrgId = 0;
            ViewBag.DepId = 0;
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
            //var org = repository.Organizations()
            //    .FirstOrDefault(x => x.OrganizationID == ViewBag.OrgId  );
            var dep = repository.Departments()
            .FirstOrDefault(x => x.DepartmentId == ViewBag.DepId);
            
            emp.Department= dep;
            
            repository.EditEmployer(emp);
            return View("Completed");
            
        }
    }
}