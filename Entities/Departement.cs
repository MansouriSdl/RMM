using RMM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.Entities
{
    public class Departement:EntityBase
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
