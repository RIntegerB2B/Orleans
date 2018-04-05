
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
   
    
    public class SKU
    {
        
        public string SkuNum { get; set; }

        
        public string Description { get; set; }

        
        public bool IsServiceSku { get; set; }

        
        public bool IsCustomerKit { get; set; }

        
        public string ItemTypeCode { get; set; }

        
        public Pricing Price { get; set; }

        
        public int Quantity { get; set; }

        
        public bool IsSystemTied { get; set; }

        
        public string ContractLaborCode { get; set; }

        #region Fields Tobe Populated

        
        public string FulfillmentLocationId { get; set; }

        
        public string ShipClass { get; set; }

        
        public bool IsSelected { get; set; }

        
        public string SkuModel { get; set; }

        
        public Guid? BundleCode { get; set; }

        
        public char Status { get; set; }

        
        public string ParentChildAttribute { get; set; }

        
        public string ClassCode { get; set; }

        
        public VariableAspect VariableAspect { get; set; }

        
        public int VariableItemGlobalIdentifier { get; set; }

        
        public Guid Id { get; set; }

        
        public string TaxClass { get; set; }

        #endregion

        
        public string LineOfBusinessId { get; set; }

        
        public string DiscountClassCode { get; set; }

        
        public string ManufacturerId { get; set; }
    }
}
