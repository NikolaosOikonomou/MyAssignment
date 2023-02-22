using MyAssignment.Models;
using MyAssignment.Models.Queries;
using MyAssignment.MyContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAssignment.Repositories
{

    /// <summary>
    ///All methods that interact with the database on behalf Employee Model
    /// </summary>
    public class EmployeeRepository
    {
        private ApplicationContext db;

        public EmployeeRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Employee> GetAll()
        {
            var employees = db.Employees.ToList();
            return employees;
        }


        /// <summary>
        /// Getting Employees plus the assosiate Managers with Eager Loading
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllWithManagers()
        {
            var employees = db.Employees.Include(x => x.Manager).ToList();
            return employees;
        }

        public Employee GetById(int? id)
        {
            var employee = db.Employees
                .Include(x => x.Manager).FirstOrDefault(x => x.Id == id);

            return employee;
        }

        public void Add(Employee employee)
        {
            db.Entry(employee).State = EntityState.Added;
            db.SaveChanges();
        }

        /// <summary>
        /// Overoload Add method to add a new Employee with a Manager
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="managerId"></param>
        public void Add(Employee emp, int? managerId)
        {

            var manager = db.Managers.Find(managerId);
            if (manager != null)
            {
                emp.ManagerId = manager.Id;
            }

            db.Entry(emp).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }


        /// <summary>
        /// Edit overload in case the EMployee we want to Update has a Manager.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="managerId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Edit(Employee emp, List<int> managerId)
        {
            if (emp == null)
            {
                throw new ArgumentException("No Manager");
            }

            var employee = db.Employees
                .Include(x => x.Manager)
                .FirstOrDefault(x => x.Id == emp.Id);

            if (employee == null)
            {
                throw new ArgumentException("No Manager found");
            }

            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.Salary = emp.Salary;
            employee.Age = emp.Age;
            employee.Country = emp.Country;

            employee.Manager = null;
            db.SaveChanges();

            if (managerId != null)
            {
                foreach (var id in managerId)
                {
                    var manager = db.Managers.Find(id);
                    if (manager != null)
                    {
                        employee.ManagerId = id;
                    }
                }
            }

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();
        }


        /// <summary>
        /// Filters the Employees based on their Lastname and their Country
        /// </summary>
        /// <param name="filterSettings"></param>
        /// <returns></returns>
        public List<Employee> Filter(EmployeeFilterSettings filterSettings)
        {
            List<Employee> employees = GetAllWithManagers();

            if (!string.IsNullOrWhiteSpace(filterSettings.searchLastName))
            {
                employees = employees.Where(x => x.LastName.ToUpper().Contains(filterSettings.searchLastName.ToUpper())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(filterSettings.searchCountry))
            {
                employees = employees.Where(x => x.Country.ToString() == filterSettings.searchCountry).ToList();
            }

            return employees;
        }
    }
}