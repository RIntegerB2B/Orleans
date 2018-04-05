using Dell.Solution.ItemApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface ISolutionConfigItemLiteGrain : Orleans.IGrainWithGuidKey
    {
        Task<SolutionConfigItemLite> GetItemLite();
        Task HydrateSolutionItemLite(ISolutionItemGrain solutionItemGrain);
    }
}
