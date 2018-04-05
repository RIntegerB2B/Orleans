using Dell.Solution.ItemApi.Model;
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
    public class SolutionConfigItemLiteGrain : Orleans.Grain<SolutionConfigItemLite>, ISolutionConfigItemLiteGrain
    {
        public Task<SolutionConfigItemLite> GetItemLite()
        {
            return GetItemLiteFromService();
        }

        /// <summary>
        /// Get the Lite Item data and add it to the Solution Item Object
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <returns></returns>
        public async Task HydrateSolutionItemLite(ISolutionItemGrain solutionItemGrain)
        {
            var solutionConfigItemLite = await GetItemLiteFromService();
            await solutionItemGrain.AddSolutionConfigItemLite(solutionConfigItemLite);
            this.DeactivateOnIdle();
        }

        #region Private Methods

        async Task<SolutionConfigItemLite> GetItemLiteFromService()
        {
            SolutionConfigItemLite solutionConfigItemLite = new SolutionConfigItemLite();
            var uri = "https://solutionitemapi.cfapps.pcf1.vc1.pcf.dell.com/api/v1/additem/uk/en/g_20204/20204/DSPER230";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                var jsonSolutionConfigItemLite = await resp.Content.ReadAsStringAsync();
                solutionConfigItemLite = JsonConvert.DeserializeObject<SolutionConfigItemLite>(jsonSolutionConfigItemLite);

                return solutionConfigItemLite;
            }
        }
        #endregion 
    }
}
