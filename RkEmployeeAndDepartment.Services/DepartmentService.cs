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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _repository;
        public DepartmentService(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _repository.All().ToListAsync();
        }
        public async Task<Department?> GetByIdAsync(Guid id)
        {
            return await _repository.Find(d => d.DepartmentId == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Department department)
        {
            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(Department department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            _repository.Update(department);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var department = await GetByIdAsync(id);
            if (department != null)
            {
                _repository.Delete(department);
                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }
        }
    }
}
