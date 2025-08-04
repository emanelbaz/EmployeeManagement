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
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext _context;
        public LogRepository(AppDbContext context) {
            _context = context; 
        }
        public async Task AddAsync(LogHistory log)
        {
            _context.LogHistories.Add(log);
        }

        public async Task<IEnumerable<LogHistory>> GetAllAsync()
        {
           return await _context.LogHistories.ToListAsync();
        }
    }
}
