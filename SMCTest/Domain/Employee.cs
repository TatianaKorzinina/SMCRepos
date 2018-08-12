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
        [Required(ErrorMessage = "введите имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "введите отчество")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "введите фамилию")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "введите адрес электронной почты")]
        [RegularExpression(".+\\@.+\\..+", 
            ErrorMessage ="введите действительный адрес электронной почты")]
        public string Email { get; set; }
        //[Required]
        //public Organization Organization { get; set; }
        [Required]
        public Department Department { get; set; }
      

    }
}
