using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public class Solution
    {
        public string Name { get; set; }

        public bool IsDirty { get; set; }

        public List<ISolutionItemGrain> SolutionItemGrains { get; set; }

        public Solution()
        {
            SolutionItemGrains = new List<ISolutionItemGrain>();
        }
    }
}
