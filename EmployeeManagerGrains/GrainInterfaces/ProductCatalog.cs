using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public class ProductCatalog
    {
        public int ModuleId { get; set; }

        public string ModuleDescription { get; set; }

        public List<ProductOption> Options { get; set; }
    }
}
