using MyAssignment.Models;
using MyAssignment.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MyAssignment.MyContext.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {

           

            #region Trainers Seeding
            Employee e1 = new Employee() { FirstName = "Antwnis", LastName = "Mpompas", Age = 36, Salary= 32000, Country = Country.Greece};
            Employee e2 = new Employee() { FirstName = "Paulos", LastName = "Soumelas", Age = 41, Salary = 40000, Country = Country .France};
            Employee e3 = new Employee() { FirstName = "Nikos", LastName = "Fousekis", Age = 46, Salary=42000, Country = Country.Portugal };
            Employee e4 = new Employee() { FirstName = "Panos", LastName = "Mpozas", Age = 34, Salary = 35000, Country = Country.Italy };
            Employee e5 = new Employee() { FirstName = "Aliki", LastName = "Koukouza", Age = 33, Salary = 34000, Country = Country.Spain };
            Employee e6 = new Employee() { FirstName = "Maria", LastName = "Papa", Age = 38, Salary = 39000, Country = Country.Spain };
            Employee e7 = new Employee() { FirstName = "John", LastName = "Olan", Age = 39, Salary = 38000, Country = Country.France };
            Employee e8 = new Employee() { FirstName = "Peris", LastName = "Papathanasiou", Age = 34, Salary = 34000, Country = Country.Greece };
            Employee e9 = new Employee() { FirstName = "Louigi", LastName = "Boufon", Age = 43, Salary = 46000, Country = Country.Italy };
            Employee e10 = new Employee() { FirstName = "Hector", LastName = "Smith", Age = 42, Salary = 42000, Country = Country.Portugal };

            context.Employees.AddOrUpdate(x => x.FirstName, e1, e2, e3, e4, e5, e6, e7, e8, e9, e10);
            context.SaveChanges();

            #endregion

            #region Managers Seeding
            Manager m1 = new Manager() { FirstName = "Panos", LastName = "Thodos", Age = 46, Salary = 50000, Country = Country.France };
            Manager m2 = new Manager() { FirstName = "Xristos", LastName = "Pyros", Age = 47, Salary = 50000, Country = Country.Greece };

            m1.Employees.Add(e1);
            m1.Employees.Add(e2);
            m1.Employees.Add(e3);
            m1.Employees.Add(e4);
            m1.Employees.Add(e5);
            m2.Employees.Add(e6);
            m2.Employees.Add(e7);
            m2.Employees.Add(e8);
            m2.Employees.Add(e9);
            m2.Employees.Add(e10);

            context.Managers.AddOrUpdate(x => x.FirstName, m1, m2);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}