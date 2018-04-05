using GrainInterface;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollection
{
    public class HydrateGrain : Orleans.Grain, IHydrateGrain
    {
        /// <summary>
        /// This will make all the background calls to hydrate the Solution
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <param name="solutionGrain"></param>
        /// <returns></returns>
        public async Task HydrateSolution(ISolutionItemGrain solutionItemGrain, string orderCode, ISolutionGrain solutionGrain, ISolutionConfigItemDetailGrain solutionConfigDetailGrain)
        {
            //await Task.Delay(1000);
            Task configDetailTask = solutionConfigDetailGrain.HydrateSolutionItemDetail(solutionItemGrain, orderCode);

            await Task.WhenAll(configDetailTask); // In future multiple tasks , if need to be added

            await solutionGrain.AddSolutionItemGrain(solutionItemGrain);
            await solutionGrain.UpdateDirtyState(false);
            Console.WriteLine("Hydrated Solution at ------" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        /// <summary>
        /// Refresh the Solution Item as there is a change
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <param name="solutionConfigItemLiteGrain"></param>
        /// <param name="solutionConfigDetailGrain"></param>
        /// <returns></returns>
        public async Task HydrateSolutionItem(ISolutionItemGrain solutionItemGrain, string orderCode, ISolutionConfigItemLiteGrain solutionConfigItemLiteGrain, ISolutionConfigItemDetailGrain solutionConfigDetailGrain)
        {
            Task configItemLiteTask = solutionConfigItemLiteGrain.HydrateSolutionItemLite(solutionItemGrain, orderCode);
            Task configDetailTask = solutionConfigDetailGrain.HydrateSolutionItemDetail(solutionItemGrain, orderCode);
            await Task.WhenAll(configItemLiteTask,configDetailTask);
            Console.WriteLine("Refreshed Solution Item at ------" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

    }
}
