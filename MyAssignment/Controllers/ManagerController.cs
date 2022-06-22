using MyAssignment.Models;
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
    public class ManagerController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private ManagerRepository managerRepository;

        private EmployeeRepository employeeRepository;

        public ManagerController()
        {
            managerRepository = new ManagerRepository(db);
            employeeRepository = new EmployeeRepository(db);
        }

        /// <summary>
        /// Action Method to Display all the Managers with Employees in the Index View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var managers = managerRepository.GetAllWithEmployees();
            return View(managers);
        }

        /// <summary>
        /// Action Method to Display Managers Details in Details View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manager = managerRepository.GetById(id);
            if (manager == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(manager);
        }


        /// <summary>
        /// ActionResult HttpGet Method to display the Create form View 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            GetEmployees();
            return View();
        }

        /// <summary>
        /// ActionResult HttpPost Method to add a new Managers in the Database
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manager manager, List<int?> employeeIds )
        {
            if (ModelState.IsValid)
            {
                if(employeeIds == null)
                {
                    managerRepository.Add(manager);
                }
                else
                {
                    managerRepository.Add(manager, employeeIds);
                }
                
                AlertMessage("Manager was successfully Created!");
                return RedirectToAction("Index");
            }

            return View(manager);
        }

        /// <summary>
        /// ActionRestult HttpGet Method to display the Delete view with the details of the selected Managers
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
            var manager = managerRepository.GetById(id);

            return View(manager);
        }

        /// <summary>
        ///ActionRestult HttpPost Method to Delete the selected Managers for the Database 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var manager = managerRepository.GetById(id);

            managerRepository.Delete(manager);
            AlertMessage("Manager was successfuly Deleted.");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// ActionResult HttpGet Method to display the selected Managers in the Edit form View
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

            var manager = managerRepository.GetById(id);
            if (manager == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            GetEmployees();
            return View(manager);
        }

        /// <summary>
        /// ActionResult HttPost Method to update the Managers's new Information in Database
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manager manager, List<int?> employeeIds)
        {
            if (ModelState.IsValid)
            {
                if(employeeIds == null)
                {
                    managerRepository.Edit(manager);
                }
                else
                {
                    managerRepository.Edit(manager, employeeIds);
                }
                
                AlertMessage("Manager was successcfully Updated!");
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

        [NonAction]
        public void GetEmployees()
        {
            var employees = employeeRepository.GetAll();
            ViewBag.Employees = employees;
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