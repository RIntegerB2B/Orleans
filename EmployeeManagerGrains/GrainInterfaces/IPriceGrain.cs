using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IPriceGrain:Orleans.IGrainWithGuidKey
    {
        Task<Pricing> GetPrice();
        Task HydrateSolutionPrice(ISolutionItemGrain solutionItemGrain);
    }
}
