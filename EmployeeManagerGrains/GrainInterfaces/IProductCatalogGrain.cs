using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IProductCatalogGrain : Orleans.IGrainWithGuidKey
    {
        Task<ProductCatalog> GetProductCatalog();
        Task HydrateSolutionProductCatalog(ISolutionItemGrain solutionItemGrain);
    }
}
