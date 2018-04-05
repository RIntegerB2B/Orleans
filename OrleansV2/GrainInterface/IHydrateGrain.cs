using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface IHydrateGrain : Orleans.IGrainWithGuidKey
    {
        Task HydrateSolution(ISolutionItemGrain solutionItemGrain, string orderCode, ISolutionGrain solutionGrain, ISolutionConfigItemDetailGrain solutionConfigDetailGrain);

        Task HydrateSolutionItem(ISolutionItemGrain solutionItemGrain,string orderCode, ISolutionConfigItemLiteGrain solutionConfigItemLiteGrain, ISolutionConfigItemDetailGrain solutionConfigDetailGrain);
    }
}
