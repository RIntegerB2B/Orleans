using GrainInterface;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SolutionAPI
    {
        IClusterClient grainClient;
        public SolutionAPI(IClusterClient client)
        {
            grainClient = client;
        }

        public Task AddProduct(string solutionId, string solutionItemId)
        {
            string solutionGrainId = solutionId;
            string solutionItemGrainId = solutionItemId;
            string orderCode = solutionItemId.Split("|")[4];
            Guid hydrateGrainId = Guid.NewGuid();
            Guid solutionConfigItemLiteGrainId = Guid.NewGuid();
            Guid solutionConfigItemDetailGrainId = Guid.NewGuid();

            var solutionGrain = grainClient.GetGrain<ISolutionGrain>(solutionGrainId);
            var solutionItemGrain = grainClient.GetGrain<ISolutionItemGrain>(solutionItemGrainId);
            var solutionConfigItemLiteGrain = grainClient.GetGrain<ISolutionConfigItemLiteGrain>(solutionConfigItemLiteGrainId);
            var solutionConfigItemDetailGrain = grainClient.GetGrain<ISolutionConfigItemDetailGrain>(solutionConfigItemDetailGrainId);
            var hydrateGrain = grainClient.GetGrain<IHydrateGrain>(hydrateGrainId);

            solutionGrain.UpdateDirtyState(true);
            solutionConfigItemLiteGrain.HydrateSolutionItemLite(solutionItemGrain, orderCode).Wait();

            // Here we will call the respective grain/MicroService to get the required data and call the Hydrate Solution. Which will hydrate the solution
            // Just pass the grain to the below method


            Task hydrateSolutionTask = hydrateGrain.HydrateSolution(solutionItemGrain, orderCode, solutionGrain, solutionConfigItemDetailGrain); // this is an asynchronous task which will hydrate the solution and make the solution not dirty

            var solutionItemData = solutionItemGrain.GetSolutionItem().Result;
            string solutionDataString = Newtonsoft.Json.JsonConvert.SerializeObject(solutionItemData);
            Console.WriteLine(solutionDataString + Environment.NewLine + "Returned the Value at --" + DateTime.Now.ToString("HH:mm:ss.fff"));
            return hydrateSolutionTask;
        }

        public async void GetSolutionItems(string solutionId)
        {
            List<SolutionItm> lstSolutionItem = new List<SolutionItm>();
            int maxTimeCounter = 20;
            int checkDirtyCounter = 0;
            string solutionGrainId = solutionId;
            var solutionGrain = grainClient.GetGrain<ISolutionGrain>(solutionGrainId);

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

            Console.WriteLine("End at - " + DateTime.Now.ToString("HH:mm:ss.fff"));
            string solutionItems = Newtonsoft.Json.JsonConvert.SerializeObject(lstSolutionItem);

            System.IO.File.WriteAllText(@"C:\My Folders\Orleans\OrleansV2\SolutionItem.txt", solutionItems);
            Console.WriteLine("Solution Items --" + solutionItems + "Retrieved at -- " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        public void RefreshOrderCode(string orderCodeId)
        {
            string solutionItemGrainId = orderCodeId;
            string orderCode = orderCodeId.Split("|")[4];
            Guid hydrateGrainId = Guid.NewGuid();
            Guid solutionConfigItemLiteGrainId = Guid.NewGuid();
            Guid solutionConfigItemDetailGrainId = Guid.NewGuid();


            var solutionItemGrain = grainClient.GetGrain<ISolutionItemGrain>(solutionItemGrainId);
            var solutionConfigItemLiteGrain = grainClient.GetGrain<ISolutionConfigItemLiteGrain>(solutionConfigItemLiteGrainId);
            var solutionConfigItemDetailGrain = grainClient.GetGrain<ISolutionConfigItemDetailGrain>(solutionConfigItemDetailGrainId);
            var hydrateGrain = grainClient.GetGrain<IHydrateGrain>(hydrateGrainId);

            hydrateGrain.HydrateSolutionItem(solutionItemGrain, orderCode, solutionConfigItemLiteGrain, solutionConfigItemDetailGrain);
            Console.WriteLine("Refreshed Order Code at --" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }
    }
}
