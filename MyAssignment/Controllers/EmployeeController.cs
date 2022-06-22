using MyAssignment.Models;
using MyAssignment.Models.Queries;
using MyAssignment.MyContext;
using MyAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private EmployeeRepository employeeRepository;

        private ManagerRepository managerRepository;

        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository(db);
            managerRepository = new ManagerRepository(db);
        }

        /// <summary>
        /// Action Method to Display all the Trainers in the Index View
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(EmployeeFilterSettings filterSettings)
        {
            //Current State
            ViewBag.currentLastName = filterSettings.searchLastName;
            ViewBag.currentCountry = filterSettings.searchCountry;

            var filterEmployees = employeeRepository.Filter(filterSettings);
            
            return View(filterEmployees);
        }

        /// <summary>
        /// Action Method to Display Trainer Details in Details View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = employeeRepository.GetById(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(employee);
        }


        /// <summary>
        /// ActionResult HttpGet Method to display the Create form View 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            GetManagers();
            return View();
        }

        /// <summary>
        /// ActionResult HttpPost Method to add a new Trainer in the Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, int? managerId)
        {
            if (ModelState.IsValid)
            {
                if(managerId == null)
                {
                    employeeRepository.Add(employee);
                }
                else
                {
                    employeeRepository.Add(employee, managerId);
                }
                
                AlertMessage("Employee was successfully Created!");
                return RedirectToAction("Index");
            }
            GetManagers();
            return View(employee);
        }

        /// <summary>
        /// ActionRestult HttpGet Method to display the Delete view with the details of the selected Trainer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var employee = employeeRepository.GetById(id);

            return View(employee);
        }

        /// <summary>
        ///ActionRestult HttpPost Method to Delete the selected Trainer for the Database 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            employeeRepository.Delete(employee);
            AlertMessage("Employee was successfuly Deleted.");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// ActionResult HttpGet Method to display the selected Trainer in the Edit form View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = employeeRepository.GetById(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            GetManagers();
            return View(employee);
        }

        /// <summary>
        /// ActionResult HttPost Method to update the Trainer's new Information in Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee, List<int> managerId)
        {
            
            if (ModelState.IsValid)
            {
                if(managerId == null)
                {
                    employeeRepository.Edit(employee);
                }
                else
                {
                    employeeRepository.Edit(employee, managerId);
                }
               
                AlertMessage("Employee was successcfully Updated!");
                return RedirectToAction("index");
            }
           
            return View();
        }

        /// <summary>
        /// NonAction Method to display massages 
        /// </summary>
        /// <param name="message"></param>
        [NonAction]
        public void AlertMessage(string message)
        {
            TempData["message"] = message;

        }


        /// <summary>
        /// Non ActionMethod to get Managers, store them in ViewBag.Managers
        /// and pass them in Create View form page.
        /// </summary>
        [NonAction]
        public void GetManagers()
        {
            var manager = managerRepository.GetAll();
            ViewBag.Managers = manager;

        }

        /// <summary>
        /// Stops the connection with the database after each interaction
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}