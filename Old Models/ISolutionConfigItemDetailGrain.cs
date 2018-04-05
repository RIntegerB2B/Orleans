using Dell.Solution.ItemApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface ISolutionConfigItemDetailGrain : Orleans.IGrainWithGuidKey
    {
        Task<SolutionConfigItemLite> GetItemDetail();
        Task HydrateSolutionItemDetail(ISolutionItemGrain solutionItemGrain);
    }
}
