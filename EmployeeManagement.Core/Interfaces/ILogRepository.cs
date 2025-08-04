using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface ILogRepository
    {
        Task<IEnumerable<LogHistory>> GetAllAsync();
        Task AddAsync(LogHistory log);
    }
}
