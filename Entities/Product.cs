using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Qr { get; set; }
        public TypeProduct Type { get; set; }
        public Guid TypeId { get; set; }
        public Section Section { get; set; }
        public Guid SectionId { get; set; }
    }
}
