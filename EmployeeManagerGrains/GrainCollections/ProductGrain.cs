using GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Newtonsoft.Json;

namespace GrainCollections
{
    [StorageProvider(ProviderName = "FileStore")]
    public class ProductGrain : Orleans.Grain<ProductDetail>, IProductGrain
    {
        public Task<ProductDetail> GetProductInfo()
        {
            return GetProductInfoFromService();
        }

        public async Task HydrateSolutionProductInfo(ISolutionItemGrain solutionItemGrain)
        {
            var prodInfo = await GetProductInfoFromService();
            await solutionItemGrain.AddProdDetail(prodInfo); // Product Info has to be added and then only Price or Validation or anoy othe rdata can be hydrated for this Solution Item
            this.DeactivateOnIdle();
        }


        #region Private Methods

        async Task<ProductDetail> GetProductInfoFromService()
        {
            ProductDetail prod = new ProductDetail();
            var uri = "http://localhost:3022";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                var jsonProdDetail = await resp.Content.ReadAsStringAsync();
                prod = JsonConvert.DeserializeObject<ProductDetail>(jsonProdDetail);

                return prod;
            }
        }
        #endregion 
    }
}
