using GrainInterfaces;
using Orleans;
using Orleans.Runtime.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SolutionAPI
    {
        IGrainFactory grainFactory;
        ClientConfiguration config;
        public SolutionAPI()
        {
            grainFactory = GrainClient.GrainFactory;
        }

        public void AddProduct(string solutionId, string orderCodeId)
        {
            string solutionGrainId = solutionId; // Persisted Grain
            string solutionItemGrainId = orderCodeId; // Persisted Grain
            Guid productGrainId = Guid.NewGuid(); // Lite
            Guid priceGrainId = Guid.NewGuid(); // Price
            Guid validationGrainId = Guid.NewGuid(); // Validation
            Guid productCatalogGrainId = Guid.NewGuid(); // Detail
            Guid hydrateGrainId = Guid.NewGuid(); // Hydrator

            var solutionGrain = grainFactory.GetGrain<ISolutionGrain>(solutionGrainId);
            var productGrain = grainFactory.GetGrain<IProductGrain>(productGrainId);
            var priceGrain = grainFactory.GetGrain<IPriceGrain>(priceGrainId);
            var validationGrain = grainFactory.GetGrain<IValidationGrain>(validationGrainId);
            var productCatalogGrain = grainFactory.GetGrain<IProductCatalogGrain>(productCatalogGrainId);
            var solutionItemGrain = grainFactory.GetGrain<ISolutionItemGrain>(solutionItemGrainId);

            solutionGrain.UpdateDirtyState(true);
            productGrain.HydrateSolutionProductInfo(solutionItemGrain).Wait();

            var hydrateGrain = grainFactory.GetGrain<IHydrateGrain>(hydrateGrainId);
            hydrateGrain.UpdateSolution(solutionItemGrain, productCatalogGrain, priceGrain, validationGrain, solutionGrain);

            var solutoinItemData = solutionItemGrain.GetSolutionItem().Result;
            string solutionDataString = Newtonsoft.Json.JsonConvert.SerializeObject(solutoinItemData);
            Console.WriteLine(solutionDataString + Environment.NewLine + "Returned the Value at --" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void AddProduct_V2(string solutionId, string solutionItemId)
        {
            string solutionGrainId = solutionId;
            string solutionItemGrainId = solutionItemId;
            Guid hydrateGrainId = Guid.NewGuid();
            Guid solutionConfigItemLiteGrainId = Guid.NewGuid();
            var solutionGrain = grainFactory.GetGrain<ISolutionGrain>(solutionGrainId);
            var solutionItemGrain = grainFactory.GetGrain<ISolutionItemGrain>(solutionItemGrainId);
            var solutionConfigItemLiteGrain = grainFactory.GetGrain<ISolutionConfigItemLiteGrain>(solutionConfigItemLiteGrainId);
            var hydrateGrain = grainFactory.GetGrain<IHydrateGrain>(hydrateGrainId);

            solutionGrain.UpdateDirtyState(true);
            solutionConfigItemLiteGrain.HydrateSolutionItemLite(solutionItemGrain).Wait();
            
            // Here we will call the respective grain/MicroService to get the required data and call the Hydrate Solution. Which will hydrate the solution
            // Just pass the grain to the below method


            hydrateGrain.HydrateSolution(solutionItemGrain,solutionGrain); // this is an asynchronous task chich will hydrate the solution and make the solution not dirty

            var solutionItemData = solutionItemGrain.GetSolutionItem().Result;
            string solutionDataString = Newtonsoft.Json.JsonConvert.SerializeObject(solutionItemData);
            Console.WriteLine(solutionDataString + Environment.NewLine + "Returned the Value at --" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void RefreshOrderCode_V2(string solutionItemId)
        {
            string solutionItemGrainId = solutionItemId;
            Guid hydrateGrainId = Guid.NewGuid();
            Guid solutionConfigItemLiteGrainId = Guid.NewGuid();

            var solutionConfigItemLiteGrain = grainFactory.GetGrain<ISolutionConfigItemLiteGrain>(solutionConfigItemLiteGrainId);
            var solutionItemGrain = grainFactory.GetGrain<ISolutionItemGrain>(solutionItemGrainId);

            var hydrateGrain = grainFactory.GetGrain<IHydrateGrain>(hydrateGrainId);
            hydrateGrain.HydrateSolutionItem(solutionItemGrain, solutionConfigItemLiteGrain);
            Console.WriteLine("Refreshed Order Code at --" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void RefreshOrderCode(string orderCodeId)
        {
            Guid productGrainId = Guid.NewGuid();
            string solutionItemGrainId = orderCodeId;
            Guid hydrateGrainId = Guid.NewGuid();
            Guid priceGrainId = Guid.NewGuid();
            Guid validationGrainId = Guid.NewGuid();
            Guid productCatalogGrainId = Guid.NewGuid();

            var productGrain = grainFactory.GetGrain<IProductGrain>(productGrainId);
            var priceGrain = grainFactory.GetGrain<IPriceGrain>(priceGrainId);
            var validationGrain = grainFactory.GetGrain<IValidationGrain>(validationGrainId);
            var productCatalogGrain = grainFactory.GetGrain<IProductCatalogGrain>(productCatalogGrainId);
            var solutionItemGrain = grainFactory.GetGrain<ISolutionItemGrain>(solutionItemGrainId);

            var hydrateGrain = grainFactory.GetGrain<IHydrateGrain>(hydrateGrainId);
            hydrateGrain.UpdateSolutionItem(solutionItemGrain, productCatalogGrain, priceGrain, validationGrain);
            Console.WriteLine("Refreshed Order Code at --" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public async void GetSolutionItems(string solutionId)
        {
            List<SolutionItem> lstSolutionItem = new List<SolutionItem>();
            int maxTimeCounter = 10;
            int checkDirtyCounter = 0;
            string solutionGrainId = solutionId;
            var solutionGrain = grainFactory.GetGrain<ISolutionGrain>(solutionGrainId);

            while (solutionGrain.CheckDirty().Result && checkDirtyCounter < maxTimeCounter)
            {
                checkDirtyCounter++;
                await Task.Delay(1000);
            }
            if (!solutionGrain.CheckDirty().Result)
            {
                List<ISolutionItemGrain> lstSolutionItemGrain = solutionGrain.GetSolutionItemGrains().Result;

                lstSolutionItemGrain.ForEach(solutionItemGrain => {
                    lstSolutionItem.Add(solutionItemGrain.GetSolutionItem().Result);
                });
            }

            string solutionItems = Newtonsoft.Json.JsonConvert.SerializeObject(lstSolutionItem);
            Console.WriteLine("Solution Items --" + solutionItems + "Retrieved at -- " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void GetPrice()
        {
            Guid priceGrainId = Guid.NewGuid();
            var priceGrain = grainFactory.GetGrain<IPriceGrain>(priceGrainId);
            var priceData = priceGrain.GetPrice().Result;
            string priceDataJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(priceData);
            Console.WriteLine("Price Data --" + priceDataJsonString + "Retrieved at -- " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void GetValidationInfo()
        {
            Guid validationInfoGrainId = Guid.NewGuid();
            var validationInfoGrain = grainFactory.GetGrain<IValidationGrain>(validationInfoGrainId);
            var validationInfoData = validationInfoGrain.GetValidationInfo().Result;
            string validationInfoDataJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(validationInfoData);
            Console.WriteLine("Validation Data --" + validationInfoDataJsonString + "Retrieved at -- " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        /// <summary>
        /// Product Catalog
        /// </summary>
        public void GetProductCatalogData()
        {
            Guid productCatalogGrainId = Guid.NewGuid();

            var productCatalogGrain = grainFactory.GetGrain<IProductCatalogGrain>(productCatalogGrainId);
            var productCatalogData = productCatalogGrain.GetProductCatalog().Result;
            string productCatalogDataJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(productCatalogData);
            Console.WriteLine("Product Catalog Data --" + productCatalogDataJsonString + "Retrieved at -- " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

    }
}
