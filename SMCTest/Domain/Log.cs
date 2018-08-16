using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log
    {
        public int LogId { get; set; }
        public DateTime dateTime { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Department { get; set; }
        public Employee Employee { get; set; }
        public LogType LogType { get; set; }
    }
}
