using Microsoft.EntityFrameworkCore;
using RkEmployeeAndDepartment.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace JpEmployeeAndDepartment.EntityFramework
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = Guid.NewGuid(), Name = "Human Resources", Location = "Head Office" },
                new Department { DepartmentId = Guid.NewGuid(), Name = "IT Department", Location = "Tech Park" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Position = "Manager" },
                new Employee { EmployeeId = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Position = "Developer" }
            );
        }
    }
}
