using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IProductGrain : Orleans.IGrainWithGuidKey
    {
        Task<ProductDetail> GetProductInfo();
        Task HydrateSolutionProductInfo(ISolutionItemGrain solutionItemGrain);
    }
}
