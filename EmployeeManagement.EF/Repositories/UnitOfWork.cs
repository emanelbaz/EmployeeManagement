using EmployeeManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }
        public ILogRepository Logs { get; }

        public UnitOfWork(AppDbContext context,
                          IEmployeeRepository employeeRepo,
                          IDepartmentRepository departmentRepo,
                          ILogRepository logRepo)
        {
            _context = context;
            Employees = employeeRepo;
            Departments = departmentRepo;
            Logs = logRepo;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}
