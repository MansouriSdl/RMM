using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class TypeProduct:EntityBase
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
