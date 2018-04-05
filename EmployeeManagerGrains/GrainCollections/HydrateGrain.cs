using GrainInterfaces;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollections
{
    /// <summary>
    /// Hydrate Grain is created to to update the Solution data async and ten to use WaitAll to update the Dirty Flag
    /// </summary>
    [StorageProvider(ProviderName = "FileStore")]
    public class HydrateGrain : Orleans.Grain<HydatedSolution>, IHydrateGrain
    {


        public Task Test(IGrainFactory grainFactory, ISolutionGrain solutionGrain, string productItemId)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// This will make all the background calls to hydrate the Solution
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <param name="solutionGrain"></param>
        /// <returns></returns>
        public async Task HydrateSolution(ISolutionItemGrain solutionItemGrain, ISolutionGrain solutionGrain)
        {
            await Task.Delay(1000);
            await solutionGrain.AddSolutionItemGrain(solutionItemGrain);
            Console.WriteLine("Hydrated Solution at ------" + DateTime.Now.ToString("HH:mm:ss.fff"));
            await solutionGrain.UpdateDirtyState(false);
        }

        public async Task HydrateSolutionItem(ISolutionItemGrain solutionItemGrain, ISolutionConfigItemLiteGrain solutionConfigItemLiteGrain )
        {
            var solutionConfigItemLiteTask = solutionConfigItemLiteGrain.HydrateSolutionItemLite(solutionItemGrain);

            await Task.WhenAll(solutionConfigItemLiteTask);
            Console.WriteLine("Hydrated Solution Item at ------" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public async Task UpdateSolution(ISolutionItemGrain solutionItemGrain, IProductCatalogGrain prodCatalogGrain, IPriceGrain priceGrain, IValidationGrain validationGrain, ISolutionGrain solutionGrain)
        {
            await Task.Delay(1000);
            var priceTask = priceGrain.HydrateSolutionPrice(solutionItemGrain);
            var validationTask = validationGrain.HydrateSolutionValidationInfo(solutionItemGrain);
            var prodCatalogGrainTask = prodCatalogGrain.HydrateSolutionProductCatalog(solutionItemGrain);

            await Task.WhenAll(priceTask, validationTask, prodCatalogGrainTask);
            await solutionGrain.AddSolutionItemGrain(solutionItemGrain);
            await solutionGrain.UpdateDirtyState(false);
            Console.WriteLine("Hydrated Solution at ------" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        /// <summary>
        /// This is called on Refreshing the order code
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <param name="prodCatalogGrain"></param>
        /// <param name="priceGrain"></param>
        /// <param name="validationGrain"></param>
        /// <returns></returns>
        public async Task UpdateSolutionItem(ISolutionItemGrain solutionItemGrain, IProductCatalogGrain prodCatalogGrain, IPriceGrain priceGrain, IValidationGrain validationGrain)
        {
            var priceTask = priceGrain.HydrateSolutionPrice(solutionItemGrain);
            var validationTask = validationGrain.HydrateSolutionValidationInfo(solutionItemGrain);
            var prodCatalogGrainTask = prodCatalogGrain.HydrateSolutionProductCatalog(solutionItemGrain);

            await Task.WhenAll(priceTask, validationTask, prodCatalogGrainTask);
            Console.WriteLine("Hydrated Solution Item at ------" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void GetSolutionItems(string solutionId)
        {
            List<SolutionItem> lstSolutionItem = new List<SolutionItem>();
            int maxTimeCounter = 10;
            int checkDirtyCounter = 0;
            string solutionGrainId = solutionId;
            var solutionGrain = GrainClient.GrainFactory.GetGrain<ISolutionGrain>(solutionGrainId);

            while (solutionGrain.CheckDirty().Result && checkDirtyCounter < maxTimeCounter)
            {
                checkDirtyCounter++;
                Task.Delay(1000);
            }
            if (solutionGrain.CheckDirty().Result)
            {
                List<ISolutionItemGrain> lstSolutionItemGrain = solutionGrain.GetSolutionItemGrains().Result;

                lstSolutionItemGrain.ForEach(solutionItemGrain => {
                    lstSolutionItem.Add(solutionItemGrain.GetSolutionItem().Result);
                });
            }

            string solutionItems = Newtonsoft.Json.JsonConvert.SerializeObject(lstSolutionItem);
            Console.WriteLine("Solution Items --" + solutionItems + "Retrieved at -- " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }
    }
}
