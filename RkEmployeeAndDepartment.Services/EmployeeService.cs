using Microsoft.EntityFrameworkCore;
using RkEmployeeAndDepartment.Contracts;
using RkEmployeeAndDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RkEmployeeAndDepartment.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.All().ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _repository.Find(e => e.EmployeeId == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            _repository.Update(employee);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _repository.Delete(employee);
                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
        }
    }
}
