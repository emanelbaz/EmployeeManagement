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
    public class DepartmentRepository  : IDepartmentRepository 
    {
        private readonly AppDbContext _context;
        public DepartmentRepository (AppDbContext context) {
            _context = context; 
        }


    public async Task AddAsync(Department department)
        {
            _context.Departments.Add(department);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
           return await _context.Departments.ToListAsync();
        }
        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }
    }

}
