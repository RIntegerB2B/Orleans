using Dell.Solution.ItemApi.Model;
using GrainInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollection
{
    public class SolutionConfigItemLiteGrain : Orleans.Grain<SolutionConfigItemLite>, ISolutionConfigItemLiteGrain
    {

        public Task<SolutionConfigItemLite> GetItemLite(string orderCode)
        {
            return GetItemLiteFromService(orderCode);
        }

        /// <summary>
        /// Get the Lite Item data and add it to the Solution Item Object
        /// </summary>
        /// <param name="solutionItemGrain"></param>
        /// <returns></returns>
        public async Task HydrateSolutionItemLite(ISolutionItemGrain solutionItemGrain, string orderCode)
        {
            var solutionConfigItemLite = await GetItemLiteFromService(orderCode);
            await solutionItemGrain.AddSolutionConfigItemLite(solutionConfigItemLite);
            this.DeactivateOnIdle();
        }

        #region Private Methods

        async Task<SolutionConfigItemLite> GetItemLiteFromService(string orderCode)
        {
            SolutionConfigItemLite solutionConfigItemLite = new SolutionConfigItemLite();
            var uri = "https://solutionitemapi.cfapps.pcf1.vc1.pcf.dell.com/api/v1/additem/uk/en/g_20204/20204/" + orderCode;
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
