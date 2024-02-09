using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class Reporting: EntityBase
    {
        public DateTime? AssignementDate { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeId { get; set; }
        public Status Status { get; set; }
        public Section Section { get; set; }
        public Guid SectionId { get; set; }
        public List<Attachement> Attachements { get; set; }
    }
}
