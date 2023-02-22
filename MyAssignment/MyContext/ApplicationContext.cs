using MyAssignment.Models;
using MyAssignment.MyContext.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MyAssignment.MyContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Sindesmos")
        {
            //Database.SetInitializer<ApplicationContext>(new MockupDbInitializer());
            //Database.Initialize(false);
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Manager> Managers { get; set; }
    }
}