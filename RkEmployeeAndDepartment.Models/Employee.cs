using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RkEmployeeAndDepartment.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public Department? Department { get; set; }
    }
}
