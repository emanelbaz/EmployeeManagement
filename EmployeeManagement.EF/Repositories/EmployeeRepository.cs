using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.EF.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
           return await  _context.Employees.FindAsync(id);
        }
       


        public async Task<IEnumerable<Employee>> GetAllAsync(string name, string department, EmployeeStatus? status, DateTime? fromDate, DateTime? toDate, string sortBy, bool isDesc)
        {
            var query = _context.Employees.Include(e => e.Department).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => e.Name.Contains(name));

            if (!string.IsNullOrEmpty(department))
                query = query.Where(e => e.Department.Name.Contains(department));

            if (status.HasValue)
                query = query.Where(e => e.Status == status.Value);

            if (fromDate.HasValue)
                query = query.Where(e => e.HireDate >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(e => e.HireDate <= toDate.Value);

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy switch
                {
                    "name" => isDesc ? query.OrderByDescending(e => e.Name) : query.OrderBy(e => e.Name),
                    "hireDate" => isDesc ? query.OrderByDescending(e => e.HireDate) : query.OrderBy(e => e.HireDate),
                    _ => query
                };
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(Employee employee) 
        { 
            await _context.Employees.AddAsync(employee);
        } 
        public Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null) _context.Employees.Remove(employee);
        }

        
    }

}
