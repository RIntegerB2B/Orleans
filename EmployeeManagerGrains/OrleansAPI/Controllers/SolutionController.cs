using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using GrainInterfaces;

namespace OrleansAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Solution")]
    public class SolutionController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30005);
            GrainClient.Initialize(config);

            // Orleans comes with a rich XML and programmatic configuration. Here we're just going to set up with basic programmatic config
            var grainFactory = GrainClient.GrainFactory;
            var solutionGrain = GrainClient.GrainFactory.GetGrain<ISolutionGrain>("123456.1|EURO");
            var productGrain = GrainClient.GrainFactory.GetGrain<IProductGrain>("123456.1|EURO|DSPEFX2");
            var priceGrain = GrainClient.GrainFactory.GetGrain<IPriceGrain>("123456.1|EURO|DSPEFX2|Price");
            var productDetail = productGrain.GetProductInfo(solutionGrain).Result;
            priceGrain.GetPrice(solutionGrain);
            return new string[] { "value1", "value2" };
        }
    }
}