using Dell.Solution.ItemApi.Model;
using System;

namespace GrainInterfaces
{
    public class SolutionItem
    {
        public string Id { get; set; }

        public string ProductKey { get; set; }

        public ProductDetail ProdDetail { get; set; }

        public Pricing Price { get; set; }

        public ProductDetail Product { get; set; }

        public ProductCatalog ProductCatalog { get; set; }

        public SolutionValidationResponse SolutionValidationResponse { get; set; }

        public SolutionConfigItemLite SolutionConfigItemLite { get; set; }

        public Guid PriceGrain { get; set; }

        public string ProductCatalogGrain { get; set; }

        public Guid ValidationGrain { get; set; }
    }
}