using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class Section:EntityBase
    { 
        public string Name { get; set; }
        public List<Product> Reportings { get; set; }
    }
}
