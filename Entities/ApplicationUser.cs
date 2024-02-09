using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
