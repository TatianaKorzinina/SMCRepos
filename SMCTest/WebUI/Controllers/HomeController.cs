using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        private IRepository repository;
        public int pageSise = 10;
        
        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        // GET: Home
        public ActionResult Index(SearchModel sear ,int page=1 )
        {
            ViewBag.p = page;
           var res = repository.Employers()
               .Where(x => sear.SearchI == null ? x == x : x.FirstName.ToLower().Contains(sear.SearchI.ToLower())
               || x.MiddleName.ToLower().Contains(sear.SearchI.ToLower())
               || x.LastName.ToLower().Contains(sear.SearchI.ToLower()));
            sear.Employes = res
               .Skip((page - 1) * pageSise)
               .Take(pageSise);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal) res.ToArray().Length / pageSise);
            return View(sear);
           
        }

        public ActionResult ShowLog(int page=1)
        {
            ViewBag.p = page;
            var logs = repository.Logs();
            var res = logs
                .Skip((page - 1) * pageSise)
               .Take(pageSise);
            ViewBag.TotalPages = (int)Math
                .Ceiling((decimal)logs.ToArray().Length / pageSise);
            return View(res); 
        }
    }
}