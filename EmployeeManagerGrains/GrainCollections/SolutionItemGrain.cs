using GrainInterfaces;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dell.Solution.ItemApi.Model;

namespace GrainCollections
{
    [StorageProvider(ProviderName = "FileStore")]
    public class SolutionItemGrain : Orleans.Grain<GrainInterfaces.SolutionItem>, ISolutionItemGrain
    {
        public override Task OnActivateAsync()
        {
            State.Id = this.GetPrimaryKeyString();
            return base.OnActivateAsync();
        }

        public async Task AddPriceInfo(GrainInterfaces.Pricing price)
        {
            State.Price = price;
            await base.WriteStateAsync();
        }

        public async Task AddValidationInfo(SolutionValidationResponse validationInfo)
        {
            State.SolutionValidationResponse = validationInfo;
            await base.WriteStateAsync();
        }

        public async Task AdProdCatalogInfo(ProductCatalog prodCatalog)
        {
            State.ProductCatalog = prodCatalog;
            await base.WriteStateAsync();
        }

        public async Task AddProdDetail(ProductDetail prodDetail)
        {
            State.ProdDetail = prodDetail;
            await base.WriteStateAsync();
        }

        public Task<GrainInterfaces.SolutionItem> GetSolutionItem()
        {
            return Task.FromResult(State);
        }

        public async Task AddSolutionConfigItemLite(SolutionConfigItemLite solutionConfigItemLite)
        {
            State.SolutionConfigItemLite = solutionConfigItemLite;
            await base.WriteStateAsync();
        }
    }
}
