using Ecommece.Core.Specifictions;
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
        Task<IEnumerable<Employee>> GetAllWithSpecAsync(ISpecifiction<Employee> spec);
        Task AddAsync(Employee employee);
        Task<Employee> GetByIdAsync(int id);
        Task UpdateAsync(Employee emp);
        Task DeleteAsync(int id);
        
    }
}
