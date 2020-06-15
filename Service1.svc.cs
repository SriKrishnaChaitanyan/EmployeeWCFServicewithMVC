using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void DeleteEmployee(int empId)
        {
            EmployeeDBModel emp = new EmployeeDBModel();

            var e = (from obj in emp.Employees
                     where obj.EmployeeId == empId
                     select obj).First();

            emp.Employees.Remove(e);
            emp.SaveChanges();

        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> emp = new List<Employee>();
            EmployeeDBModel obj = new EmployeeDBModel();
            emp = obj.Employees.ToList();

            return emp;

        }

        public void InsertEmployee(Employee emp)
        {
            EmployeeDBModel obj = new EmployeeDBModel();
            obj.Employees.Add(emp);
            obj.SaveChanges();

        }

        public void UpdateEmployee(Employee emp)
        {
            EmployeeDBModel obj = new EmployeeDBModel();
            var c = (from e in obj.Employees
                     where e.EmployeeId == emp.EmployeeId
                     select e).First();

            c.EmployeeName = emp.EmployeeName;
            c.EmployeeSal = emp.EmployeeSal;
            c.EmployeeAddress = emp.EmployeeAddress;
            c.Street = emp.Street;
            c.City = emp.City;
            c.State = emp.State;

            obj.SaveChanges();

        }
    }
}
