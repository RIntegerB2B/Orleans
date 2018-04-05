using GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dell.Solution.SCS.Service.Controllers
{
    [Route("api/Solution")]
    public class SolutionController : ApiController
    {
        [Route("AddProduct")]
        [HttpGet]
        public ProductDetail Get(string solutionId, string orderCodeId, string rgn)
        {
            //var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30005);
            //GrainClient.Initialize(config);
            //var grainFactory = GrainClient.GrainFactory;

            //string solutionGrainId = "12345.1" + "|" + "EURO";
            //string productGrainId = "H224H";
            //Guid solutionItemGrainId = Guid.NewGuid();
            //Guid hydrateGrainId = Guid.NewGuid();
            //Guid priceGrainId = Guid.NewGuid();
            //Guid validationGrainId = Guid.NewGuid();
            //string productCatalogGrainId = "H224H|CategoryPath";

            //var solutionGrain = GrainClient.GrainFactory.GetGrain<ISolutionGrain>(solutionGrainId);
            //var productGrain = GrainClient.GrainFactory.GetGrain<IProductGrain>(productGrainId);
            //var priceGrain = grainFactory.GetGrain<IPriceGrain>(priceGrainId);
            //var validationGrain = GrainClient.GrainFactory.GetGrain<IValidationGrain>(validationGrainId);
            //var productCatalogGrain = GrainClient.GrainFactory.GetGrain<IProductCatalogGrain>(productCatalogGrainId);
            //var solutionItemGrain = GrainClient.GrainFactory.GetGrain<ISolutionItemGrain>(solutionItemGrainId);
            //var productDetail = productGrain.GetProductInfo(solutionGrain).Result; // This will add the Product Detail into Solution Grain and then come to next statement as the Solution Item id is needed for further hydration

            //var hydrateGrain = GrainClient.GrainFactory.GetGrain<IHydrateGrain>(hydrateGrainId);
            //hydrateGrain.UpdateSolution(solutionItemGrain, productCatalogGrain, priceGrain, validationGrain, solutionGrain, productDetail.ProductItemId);



            return new ProductDetail();
        }
    }
}
