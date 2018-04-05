using GrainInterface;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dell.Solution.ItemApi.Model;

namespace GrainCollection
{
    public class SolutionItemGrain : Orleans.Grain<GrainInterface.SolutionItm>, ISolutionItemGrain
    {
        public override Task OnActivateAsync()
        {
            State.Id = this.GetPrimaryKeyString();
            return base.OnActivateAsync();
        }


        public Task<GrainInterface.SolutionItm> GetSolutionItem()
        {
            return Task.FromResult(State);
        }

        public async Task AddSolutionConfigItemLite(SolutionConfigItemLite solutionConfigItemLite)
        {
            State.SolutionConfigItemLite = solutionConfigItemLite;
            await base.WriteStateAsync();
        }

        public async Task AddSolutionConfigItem(SolutionConfigItem solutionConfigItem)
        {
            State.SolutionConfigItem = solutionConfigItem;
            await base.WriteStateAsync();
        }
    }
}
