using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dell.Solution.ItemApi.Model;

namespace GrainInterfaces
{
    public interface ISolutionItemGrain : Orleans.IGrainWithStringKey
    {
        Task AddPriceInfo(Pricing price);
        Task AdProdCatalogInfo(ProductCatalog prodCatalog);
        Task AddValidationInfo(SolutionValidationResponse validationInfo);
        Task AddProdDetail(ProductDetail prodDetail);
        Task<SolutionItem> GetSolutionItem();
        Task AddSolutionConfigItemLite(SolutionConfigItemLite solutionConfigItemLite);
    }
}
