using AutoMapper;
using EmployeeManagement.Core.Models;

namespace EmployeeManagementAPI.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
