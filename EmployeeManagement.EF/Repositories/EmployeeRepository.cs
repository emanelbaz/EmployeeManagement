using Ecommece.Core.Specifictions;
using Ecommece.EF.Data;
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



        public async Task<IEnumerable<Employee>> GetAllWithSpecAsync(ISpecifiction<Employee> spec)
        {
            var query = SpecificationEvaluator<Employee>.GetQuery(_context.Employees.AsQueryable(), spec);
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
