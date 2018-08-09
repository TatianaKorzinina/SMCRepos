using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain
{   [Table("Employes")]
    public class Employee
    {
        [HiddenInput(DisplayValue =false)]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        //[Required]
        //public Organization Organization { get; set; }
        [Required]
        public Department Department { get; set; }
      

    }
}
