using AutoMapper;
using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Specifictions;
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

        [HttpGet]
        public async Task<IActionResult> GetEmployees(
            [FromQuery] string name,
            [FromQuery] string department,
            [FromQuery] EmployeeStatus? status,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] string sortBy,
            [FromQuery] bool desc,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {
            var spec = new EmployeeSpecification(name, department, status, from, to, sortBy, desc, pageIndex, pageSize);

            var employees = await _unitOfWork.Employees.GetAllWithSpecAsync(spec);

            var data = _mapper.Map<IEnumerable<EmployeeResponse>>(employees);

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
