using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequest dto)
        {
            var emp = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                HireDate = dto.HireDate,
                DepartmentId = dto.DepartmentId,
                Status = dto.Status
            };

            await _unitOfWork.Employees.AddAsync(emp);

            await _unitOfWork.Logs.AddAsync(new LogHistory
            {
                EmployeeId = emp.Id,
                Action = "Created",
                Timestamp = DateTime.UtcNow
            });

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name, string department, EmployeeStatus? status, DateTime? from, DateTime? to, string sortBy, bool desc)
        {
            var result = await _unitOfWork.Employees.GetAllAsync(name, department, status, from, to, sortBy, desc);
            return Ok(result);
        }
    }

}
