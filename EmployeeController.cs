using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmployeeClientwithWCF.ServiceReference1;

namespace MVCEmployeeClientwithWCF.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetMVCEmployees()
        {
            Service1Client servObj = new Service1Client();
            List<Employee> empObj = servObj.GetEmployees().ToList();

            return View(empObj);
        }
        public ActionResult InsertMVCEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertMVCEmployee(Employee emp)
        {
            Service1Client servObj = new Service1Client();
            servObj.InsertEmployee(emp);

            return RedirectToAction("GetMVCEmployees", "Employee");
        }

        [HttpGet]
        public ActionResult UpdateMVCEmployee(int empId)
        {
            Service1Client servObj = new Service1Client();
            
            var c = (from e in servObj.GetEmployees().ToList()
                     where e.EmployeeId == empId
                     select e).First();
            
            Employee emp = (Employee)c;
            return View(emp);
        }

        [HttpPost]
        public ActionResult UpdateMVCEmployee(Employee emp)
        {
            Service1Client servObj = new Service1Client();
            servObj.UpdateEmployee(emp);

            return RedirectToAction("GetMVCEmployees", "Employee");
        }

        [HttpGet]
        public ActionResult DeleteMVCEmployee(int empId)
        {
            Service1Client servObj = new Service1Client();

            var c = (from e in servObj.GetEmployees().ToList()
                     where e.EmployeeId == empId
                     select e).First();

            Employee emp = (Employee)c;

            return View(emp);
            
        }

        [HttpPost, ActionName("DeleteMVCEmployee")]
        public ActionResult DeleteMVCEmployeePost(int empId)
        {
            Service1Client servObj = new Service1Client();
            servObj.DeleteEmployee(empId);

            return RedirectToAction("GetMVCEmployees", "Employee");
        }

        [HttpGet]
        public ActionResult DetailsMVCEmployee(int empId)
        {
            Service1Client servObj = new Service1Client();

            var c = (from e in servObj.GetEmployees().ToList()
                     where e.EmployeeId == empId
                     select e).First();

            Employee emp = (Employee)c;

            return View(emp);

        }

    }
}