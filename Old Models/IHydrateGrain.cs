using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface IHydrateGrain : Orleans.IGrainWithGuidKey
    {
        Task HydrateSolution(ISolutionItemGrain solutionItemGrain, ISolutionGrain solutionGrain);

        Task HydrateSolutionItem(ISolutionItemGrain solutionItemGrain, ISolutionConfigItemLiteGrain solutionConfigItemLiteGrain);
    }
}
