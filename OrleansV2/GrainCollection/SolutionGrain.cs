using GrainInterface;
using Orleans.Concurrency;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollection
{
    [Reentrant] // Prod , Price Validation Grains can call concurrently
    public class SolutionGrain : Orleans.Grain<GrainInterface.Solution>, ISolutionGrain
    {
        public Task<Solution> GetSolutionState()
        {
            return Task.FromResult(State);
        }

        public async Task UpdateDirtyState(bool isDirty)
        {
            State.IsDirty = isDirty;
            Console.WriteLine("IsDirty - " + isDirty.ToString());
            await base.WriteStateAsync();
        }
        public Task<bool> CheckDirty()
        {
            return Task.FromResult(State.IsDirty);
        }

        public async Task AddSolutionItemGrain(ISolutionItemGrain solutionItemGrain)
        {
            if (!State.SolutionItemGrains.Contains(solutionItemGrain))
                State.SolutionItemGrains.Add(solutionItemGrain);
            await base.WriteStateAsync();
        }

        public Task<List<ISolutionItemGrain>> GetSolutionItemGrains()
        {
            return Task.FromResult(State.SolutionItemGrains);
        }
    }
}
