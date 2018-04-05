using Dell.Solution.ItemApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface ISolutionConfigItemLiteGrain: Orleans.IGrainWithGuidKey
    {
        Task<SolutionConfigItemLite> GetItemLite();
        Task HydrateSolutionItemLite(ISolutionItemGrain solutionItemGrain);
    }
}
