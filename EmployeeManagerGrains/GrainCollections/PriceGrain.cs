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
    public class PriceGrain : Orleans.Grain<Pricing>, IPriceGrain
    {
        public Task<Pricing> GetPrice()
        {
            return GetPriceInfoFromService();
        }

        public async Task HydrateSolutionPrice(ISolutionItemGrain solutionItemGrain)
        {
            var priceInfo = await GetPriceInfoFromService();
            await solutionItemGrain.AddPriceInfo(priceInfo);
            this.DeactivateOnIdle();
        }

        #region Private Methods

        async Task<Pricing> GetPriceInfoFromService()
        {
            Pricing price = new Pricing();
            var uri = "http://localhost:3021";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                var jsonPriceDetail = await resp.Content.ReadAsStringAsync();
                price = JsonConvert.DeserializeObject<Pricing>(jsonPriceDetail);

                return price;
            }
        }
        #endregion 
    }
}
