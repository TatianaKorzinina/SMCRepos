using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SMCContext: DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employes { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
