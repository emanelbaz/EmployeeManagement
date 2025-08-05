using AutoMapper;
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
        private readonly IMapper _mapper;
        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);

            await _unitOfWork.Employees.AddAsync(employee);

            await _unitOfWork.SaveChangesAsync();

            var log = new LogHistory
            {
                EmployeeId = employee.Id,
                Action = "Created",
                Timestamp = DateTime.UtcNow
            };

            await _unitOfWork.Logs.AddAsync(log);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string name,
            [FromQuery] string department,
            [FromQuery] EmployeeStatus? status,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] string sortBy,
            [FromQuery] bool desc)
        {
            var employees = await _unitOfWork.Employees
                .GetAllAsync(name, department, status, from, to, sortBy, desc);

            var response = _mapper.Map<IEnumerable<EmployeeResponse>>(employees);

            return Ok(response);
        }
    }

}
