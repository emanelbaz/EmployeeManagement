using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(string name, string department, EmployeeStatus? status, DateTime? from, DateTime? to, string sortBy, bool desc);
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee emp);
        Task UpdateAsync(Employee emp);
        Task DeleteAsync(int id);
        
    }
}
