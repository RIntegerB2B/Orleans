using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IValidationGrain : Orleans.IGrainWithGuidKey
    {
        Task<SolutionValidationResponse> GetValidationInfo();
        Task<SolutionValidationResponse> HydrateSolutionValidationInfo(ISolutionItemGrain solutionItemGrain);
    }
}
