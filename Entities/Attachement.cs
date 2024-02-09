using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class Attachement:EntityBase
    {
        public byte[] File { get; set; }
        public Reporting Reporting { get; set; }
        public Guid ReportingId { get; set; }
    }
}
