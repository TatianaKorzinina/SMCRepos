using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable();
            Console.ReadLine();
        }

        static void CreateTable()
        {
            var org = new Organization { OrganizationTitle = "SMC Pneumatik", };
            using (var context = new SMCContext())
            {
                var res = context.Employes
                    .Include("Department")
                    .Include("Department.Organization");
                foreach (var r in res)
                {
                    Console.WriteLine(r.FirstName + " " + r.LastName + " " + r.Department.DepartmentTitle + " " + r.Department.Organization.OrganizationTitle);
                }
            }
        }
    }
}
