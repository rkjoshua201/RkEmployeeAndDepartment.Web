using RkEmployeeAndDepartment.Models;
using RkEmployeeAndDepartment.Contracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RkEmployeeAndDepartment.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Department> Departments { get; set; } = new List<Department>();

        public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public async Task OnGetAsync()
        {
            Employees = (await _employeeService.GetAllAsync()).ToList();
            Departments = (await _departmentService.GetAllAsync()).ToList();
        }
    }
}
