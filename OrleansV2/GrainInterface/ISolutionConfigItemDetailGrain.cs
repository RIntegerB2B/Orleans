using Dell.Solution.ItemApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface ISolutionConfigItemDetailGrain : Orleans.IGrainWithGuidKey
    {
        Task<SolutionConfigItem> GetItemDetail(string orderCode);
        Task HydrateSolutionItemDetail(ISolutionItemGrain solutionItemGrain, string orderCode);
    }
}
