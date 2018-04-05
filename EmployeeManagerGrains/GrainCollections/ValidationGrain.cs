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
    public class ValidationGrain : Orleans.Grain<SolutionValidationResponse>, IValidationGrain
    {
        public Task<SolutionValidationResponse> GetValidationInfo()
        {
            return GetValidationInfoFromService();
        }

        public async Task<SolutionValidationResponse> HydrateSolutionValidationInfo(ISolutionItemGrain solutionItemGrain)
        {
            var validationInfo = await GetValidationInfoFromService();
            await solutionItemGrain.AddValidationInfo(validationInfo);
            return validationInfo;
        }

        #region Private Methods

        async Task<SolutionValidationResponse> GetValidationInfoFromService()
        {
            SolutionValidationResponse validationResponse = new SolutionValidationResponse();
            var uri = "http://localhost:3020";
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                var jsonProdDetail = await resp.Content.ReadAsStringAsync();
                validationResponse = JsonConvert.DeserializeObject<SolutionValidationResponse>(jsonProdDetail);

                return validationResponse;
            }
        }
        #endregion 
    }
}
