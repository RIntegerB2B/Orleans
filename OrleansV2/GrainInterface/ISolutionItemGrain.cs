using Dell.Solution.ItemApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface ISolutionItemGrain : Orleans.IGrainWithStringKey
    {
        Task<SolutionItm> GetSolutionItem();
        Task AddSolutionConfigItemLite(SolutionConfigItemLite solutionConfigItemLite);
        Task AddSolutionConfigItem(SolutionConfigItem solutionConfigItem);
    }
}
