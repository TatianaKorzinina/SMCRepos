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
            
            using (var context = new SMCContext())
            {
                var emp = new Log
                {
                    FirstName = "Лиза",
                    
                };
                //context.Log.Add(emp);
                context.SaveChanges();
            }
        }
    }
}
