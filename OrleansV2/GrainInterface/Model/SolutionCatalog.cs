using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class SolutionCatalog
    {
        public SolutionCatalog()
        {
            CustomerSet = new CustomerSet();
        }

        
        public int Id { get; set; }

        
        public int CompanyNumber { get; set; }

        
        public CustomerSet CustomerSet { get; set; }

        
        public string LanguageCode { get; set; }

        
        public int LanguageId { get; set; }

        
        public string CurrencyCode { get; set; }

        
        public string CountryCode { get; set; }

        
        public int BusinessUnitId { get; set; }
        //public string Region { get; set; }

        
        public string DefaultLanguage { get; set; }

        
        public string DefaultCultureInfoName { get; set; }

        
        public string DefaultSolutionCustomerSet { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public string DisplayCountryCode { get; set; }

        
        public int CustomerTypeId { get; set; }

        
        public int SnaCatalogId { get; set; }

        
        public long? OrgId { get; set; }
    }

    
    public class CustomerSet 
    {
      //  public CustomerSet();

        
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public CustomerSetType Type { get; set; }
        public string CacheKey { get; }
    }
}
