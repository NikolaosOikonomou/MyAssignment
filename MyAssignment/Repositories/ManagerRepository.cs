using MyAssignment.Models;
using MyAssignment.MyContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAssignment.Repositories
{
    /// <summary>
    ///All methods that interact with the database on behalf Manager Model
    /// </summary>
    public class ManagerRepository
    {
        private ApplicationContext db;

        public ManagerRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Manager> GetAll()
        {
            var managers = db.Managers.ToList();
            return managers;
        }

        public List<Manager> GetAllWithEmployees()
        {
            var managers = db.Managers.Include(x=>x.Employees).ToList();
            return managers;
        }

        public Manager GetById(int? id)
        {
            var manager = db.Managers
                .Include(x=>x.Employees).FirstOrDefault(x => x.Id == id);
            return manager;
        }

        public void Add(Manager manager)
        {
            db.Entry(manager).State = EntityState.Added;
            db.SaveChanges();
        }

        /// <summary>
        /// OverLoad Add Method in case new Manager has employees
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="employeeIds"></param>
        public void Add(Manager manager, List<int?> employeeIds)
        {

            foreach (var id in employeeIds)
            {
                var employee = db.Employees.Find(id);
                if (employee != null)
                {
                    manager.Employees.Add(employee);
                }
            }

            db.Entry(manager).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Manager manager)
        {
            db.Entry(manager).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// OVerload Edit in case the selected Manager has employee
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="managerId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Edit(Manager manager, List<int?> employeesIds)
        {
            if (manager == null)
            {
                throw new ArgumentException("No employee");
            }

            var tempManager = db.Managers
                .Include(x => x.Employees)
                .FirstOrDefault(x => x.Id == manager.Id);

            if (tempManager == null)
            {
                throw new ArgumentException("No employee found");
            }

            tempManager.FirstName = manager.FirstName;
            tempManager.LastName = manager.LastName;
            tempManager.Salary = manager.Salary;
            tempManager.Age = manager.Age;
            tempManager.Country = manager.Country;

            tempManager.Employees.Clear();
            db.SaveChanges();

            if (employeesIds != null)
            {
                foreach (var id in employeesIds)
                {
                    var employee = db.Employees.Find(id);
                    if (employee != null)
                    {
                        tempManager.Employees.Add(employee);
                    }
                }
            }

            db.Entry(tempManager).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Manager manager)
        {
            db.Entry(manager).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}