using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        [Required]
        public string OrganizationTitle { get; set; }
        
        public List<Department> Departments { get; set; }
        
        //public List<Employee> Employes { get; set; }

    }
}
