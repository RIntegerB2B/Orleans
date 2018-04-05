using GrainInterface;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dell.Solution.ItemApi.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace GrainCollection
{
    public class SolutionConfigItemDetailGrain : Orleans.Grain<SolutionConfigItem>, ISolutionConfigItemDetailGrain
    {
        public Task<SolutionConfigItem> GetItemDetail(string orderCode)
        {
            return GetItemDetailFromService(orderCode);
        }

        /// <summary>
        /// Get the Lite Item data and add it to the Solution Item Object
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <returns></returns>
        public async Task HydrateSolutionItemDetail(ISolutionItemGrain solutionItemGrain, string orderCode)
        {
            var solutionConfigItem = await GetItemDetailFromService(orderCode);
            await solutionItemGrain.AddSolutionConfigItem(solutionConfigItem);
            this.DeactivateOnIdle();
        }

        #region Private Methods

        async Task<SolutionConfigItem> GetItemDetailFromService(string orderCode)
        {
            SolutionConfigItem solutionConfigItem = new SolutionConfigItem();
            var uri = "https://solutionitemapi.cfapps.pcf1.vc1.pcf.dell.com/api/v1/additem/details/uk/en/g_20204/20204/" + orderCode;
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                var jsonSolutionConfigItem = await resp.Content.ReadAsStringAsync();
                solutionConfigItem = JsonConvert.DeserializeObject<SolutionConfigItem>(jsonSolutionConfigItem);

                return solutionConfigItem;
            }
        }
        #endregion 
    }
}
