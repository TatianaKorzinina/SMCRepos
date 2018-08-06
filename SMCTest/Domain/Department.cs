using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentTitle { get; set; }
       
        public List<Employee> Employes { get; set; }
        [Required]
        public Organization Organization { get; set; }
    }
}
