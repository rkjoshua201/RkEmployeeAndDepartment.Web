using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RkEmployeeAndDepartment.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
