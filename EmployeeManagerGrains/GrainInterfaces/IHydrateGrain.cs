using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IHydrateGrain : Orleans.IGrainWithGuidKey
    {
        Task UpdateSolution(ISolutionItemGrain solutionItemGrain, IProductCatalogGrain prodCatalogGrain, IPriceGrain priceGrain, IValidationGrain validationGrain, ISolutionGrain solutionGrain);

        Task UpdateSolutionItem(ISolutionItemGrain solutionItemGrain, IProductCatalogGrain prodCatalogGrain, IPriceGrain priceGrain, IValidationGrain validationGrain);

        Task HydrateSolution(ISolutionItemGrain solutionItemGrain, ISolutionGrain solutionGrain);

        Task HydrateSolutionItem(ISolutionItemGrain solutionItemGrain, ISolutionConfigItemLiteGrain solutionConfigItemLiteGrain);
    }
}
