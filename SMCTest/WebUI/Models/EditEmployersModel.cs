using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Domain;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class EditEmployersModel
    {  
        public Employee Employee { get; set; }

        
        public int DepId { get; set; }
        

    }
}