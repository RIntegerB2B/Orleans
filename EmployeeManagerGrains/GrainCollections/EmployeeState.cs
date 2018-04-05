using GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollections
{
    public class EmployeeState
    {

        public int Level { get; set; }
        public IManager Manager { get; set; }
    }
}
