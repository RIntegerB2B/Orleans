using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface ISolutionGrain:Orleans.IGrainWithStringKey
    {
        Task<string> AddSolutionItems();
        Task AddProductInfo(ProductDetail prodDetail);
        //Task<string> GetProductInfo(IProductGrain prodGrain);
        //Task<string> GetPriceInfo(IPriceGrain priceGrain);
        Task<Solution> GetSolutionState();
        Task AddPriceInfo(Pricing price, string productItemId);
        Task AdProdCatalogInfo(ProductCatalog priceInfo, string productItemId);
        Task AddValidationInfo(SolutionValidationResponse validationInfo, string productItemId);
        Task AddSolutionItemGrain(ISolutionItemGrain solutionItemGrain);
        Task<bool> CheckDirty();
        Task UpdateDirtyState(bool isDirty);
        Task<List<ISolutionItemGrain>> GetSolutionItemGrains();
    }
}
