using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface ISolutionGrain : Orleans.IGrainWithStringKey
    {
        Task<Solution> GetSolutionState();
        Task<bool> CheckDirty();
        Task UpdateDirtyState(bool isDirty);
        Task<List<ISolutionItemGrain>> GetSolutionItemGrains();
        Task AddSolutionItemGrain(ISolutionItemGrain solutionItemGrain);
    }
}
