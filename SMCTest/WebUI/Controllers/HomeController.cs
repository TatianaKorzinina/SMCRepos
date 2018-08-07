using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        private IRepository repository;
        public int pageSise = 4;
        
        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        // GET: Home
        public ActionResult Index(int page=1)
        {
            var result = repository.Employers().Skip((page-1)*pageSise)
                .Take(pageSise);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal) repository.Employers().ToArray().Length / pageSise);
            return View(result);
            
        }
    }
}