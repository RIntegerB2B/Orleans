using GrainInterfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Orleans;
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
    public class StockGrain : Orleans.Grain<Price>, IStockGrain
    {
        string price;
        string product;

        public override async Task OnActivateAsync()
        {
            string stock;
            this.GetPrimaryKey(out stock);
            //await UpdatePrice();

            //var timer = RegisterTimer(
            //    UpdatePrice,
            //    stock,
            //    TimeSpan.FromMinutes(1),
            //    TimeSpan.FromMinutes(1));

            await base.OnActivateAsync();
        }

        public async Task UpdatePrice()
        {
            // collect the task variables without awaiting
            
            var priceTask = GetPricefromService();
            var productTask = GetProductFromService();

            // await both tasks
            await Task.WhenAll(productTask, priceTask);

            // read the results
            price = priceTask.Result;
            State.ProductPrice = price;
            product = productTask.Result;
            
            await base.WriteStateAsync();
            Console.WriteLine(price);
            Console.WriteLine(product);
        }

       

        async Task<string> GetPricefromService()
        {
            // retrieve the graph data from Yahoo finance
            var uri = "http://localhost:3021";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                return await resp.Content.ReadAsStringAsync();
            }
        }

        async Task<string> GetProductFromService()
        {
            var uri = "http://localhost:3020";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public Task<string> GetPrice()
        {
            return Task.FromResult(State.ProductPrice);
        }
    }
}
