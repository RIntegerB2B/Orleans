using GrainInterfaces;
using Newtonsoft.Json;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollections
{
    [StorageProvider(ProviderName = "FileStore")]
    public class ProductCatalogGrain : Orleans.Grain<ProductCatalog>, IProductCatalogGrain
    {
        public Task<ProductCatalog> GetProductCatalog()
        {
            return GetProductCatalogFromService();
        }

        public async Task HydrateSolutionProductCatalog(ISolutionItemGrain solutionItemGrain)
        {
            var prodCatalog = await GetProductCatalogFromService();
            State = prodCatalog;
            await solutionItemGrain.AdProdCatalogInfo(prodCatalog);
            this.DeactivateOnIdle();
        }


        #region Private Methods

        async Task<ProductCatalog> GetProductCatalogFromService()
        {
            ProductCatalog prodCatalog = new ProductCatalog();
            var uri = "http://localhost:3023";
            var microServiceAPI = "https://solutionitemapi.cfapps.pcf1.vc1.pcf.dell.com/api/v1/additem/uk/en/g_20204/20204/DSPER230";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                var jsonPriceDetail = await resp.Content.ReadAsStringAsync();
                prodCatalog = JsonConvert.DeserializeObject<ProductCatalog>(jsonPriceDetail);

                return prodCatalog;
            }
        }
        #endregion 
    }
}
