using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifieddBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
