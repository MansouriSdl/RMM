using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class Employee:EntityBase
    {
        public string FullName { get; set; }
        public string WorkId { get; set; }
        public string Adresse { get; set; }
        public string IdentityCard { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Departement Departement { get; set; }
        public Guid DepartementId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
