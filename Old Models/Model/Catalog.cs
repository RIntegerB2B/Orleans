
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class Category
    {
        
        public string Id { get; set; }

        
        public string Name { get; set; }

        
        public List<Module> Modules { get; set; }

        
        public int Sequence { get; set; }

        
        public string OrderInstructions { get; set; }
    }
}
