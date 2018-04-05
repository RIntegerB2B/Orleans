using GrainInterfaces;
using Orleans.Concurrency;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollections
{
    [StorageProvider(ProviderName = "FileStore")]
    [Reentrant] // Prod , Price Validation Grains can call concurrently
    public class SolutionGrain : Orleans.Grain<GrainInterfaces.Solution>, ISolutionGrain
    {
        public Task<string> AddSolutionItems()
        {
            return Task.FromResult("Added Succesfully");
        }

        public  Task<Solution> GetSolutionState()
        {
            return Task.FromResult(State);
        }

        public async Task AddProductInfo(ProductDetail prodDetail)
        {
            Console.WriteLine("Written Outside Solution state");
            State.IsDirty = true;
            SolutionItem solnItem = new SolutionItem {
                Id=prodDetail.ProductItemId,
                ProductKey=prodDetail.ProductItemId
            };
            //State.SolutionItems.Add(solnItem);
            Console.WriteLine("Written inside Solution state");
            await base.WriteStateAsync();
        }

        public async Task AddPriceInfo(Pricing price, string productItemId)
        {
           // State.SolutionItems.Find(item => item.Id == productItemId).Price = price;
            await base.WriteStateAsync();
        }

        public async Task AddValidationInfo(SolutionValidationResponse validationInfo, string productItemId)
        {
           // State.SolutionItems.Find(item => item.Id == productItemId).SolutionValidationResponse = validationInfo;
            await base.WriteStateAsync();
        }

        public async Task AdProdCatalogInfo(ProductCatalog prodCatalog, string productItemId)
        {
            //State.SolutionItems.Find(item => item.Id == productItemId).ProductCatalog = prodCatalog;
            await base.WriteStateAsync();
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

        public async Task  AddSolutionItemGrain(ISolutionItemGrain solutionItemGrain)
        {
            if(!State.SolutionItemGrains.Contains(solutionItemGrain))
                State.SolutionItemGrains.Add(solutionItemGrain);
            await base.WriteStateAsync();
        }

        public Task<List<ISolutionItemGrain>> GetSolutionItemGrains()
        {
            return Task.FromResult(State.SolutionItemGrains);
        }
    }
}
