﻿using Domain;
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
                var emp = new Employee
                {
                    FirstName = "Лиза",
                    MiddleName = "Алексеевна",
                    LastName = "Ефимова",
                    Email = "вава@na.ru",
                    Department = context.Departments.Find(1)
                };
                context.Employes.Add(emp);
                context.SaveChanges();
            }
        }
    }
}
