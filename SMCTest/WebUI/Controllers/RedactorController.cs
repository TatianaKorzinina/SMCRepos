using Domain;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            ViewBag.Depart = repository.Employers().ToList();
          
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            repository.EditEmployer(employee);
            return View("Completed");
        }
    }
}