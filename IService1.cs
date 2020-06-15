using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace EmployeeWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        IEnumerable<Employee> GetEmployees();

        [OperationContract]
        void InsertEmployee(Employee emp);

        [OperationContract]
        void UpdateEmployee(Employee emp);

        [OperationContract]
        void DeleteEmployee(int empId);

        
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        [Key]
        [Required]
        public int EmployeeId { get; set; }
        
        [DataMember]
        [Required]
        public string EmployeeName { get; set; }

        [DataMember]
        [Required]
        public int EmployeeSal { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        [Required]
        public string EmployeeAddress { get; set;  }

    }
}
