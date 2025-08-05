using Ecommece.Core.Specifictions;
using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeManagement.Core.Specifictions
{
    public class EmployeeSpecification : BaseSpecifiction<Employee>
    {
        public EmployeeSpecification(
            string? name,
            string? department,
            EmployeeStatus? status,
            DateTime? from,
            DateTime? to,
            string? sortBy,
            bool desc,
            int pageNumber=1,
            int pageSize=10)
        {
            // filter
            Criteria = emp =>
                (string.IsNullOrEmpty(name) || emp.Name.Contains(name)) &&
                (string.IsNullOrEmpty(department) || emp.Department.Name.Contains(department)) &&
                (!status.HasValue || emp.Status == status.Value) &&
                (!from.HasValue || emp.HireDate >= from.Value) &&
                (!to.HasValue || emp.HireDate <= to.Value);

            // Includes
            AddInclude(emp => emp.Department);

            // order
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (desc)
                    AddorderByDesc(e => EF.Property<object>(e, sortBy));
                else
                    AddorderBy(e => EF.Property<object>(e, sortBy));
            }
            else
            {
                AddorderByDesc(e => e.HireDate);
            }

            // Paging
            ApplayPaging((pageNumber - 1) * pageSize, pageSize);
        }
    }
}
