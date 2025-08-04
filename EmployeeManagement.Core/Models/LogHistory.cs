using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Models
{
    public class LogHistory:BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
