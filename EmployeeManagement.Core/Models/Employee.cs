using EmployeeManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Models
{
    public class Employee : BaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public EmployeeStatus Status { get; set; }
    }
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; } 
    }
}
