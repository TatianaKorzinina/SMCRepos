using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebUI.Models
{
    public class SearchModel
    {
        public string SearchI { get; set; }
        public IEnumerable<Employee> Employes {get;set;}
    }
}