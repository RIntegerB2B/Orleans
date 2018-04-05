using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class SolutionSkuItem : SolutionItem
    {
        
        private SKU _sku;

        
        private int _quantity;

        
        public LineItemSource Source { get; set; }

        
        public bool IsTied { get; set; }

        
        public Guid ParentId { get; set; }

        
        public List<Unit> Units { get; set; }

        public SKU Sku
        {
            get
            {
                return _sku;
            }
            set
            {
                _sku = value;
            }
        }

        
        public UserAction Action { get; set; }

        
        public bool PassedBusinessRules { get; set; }

        
        public string ContractLaborCode { get; set; }

        
        public string ItemTypeCode { get; set; }

        
        public int CoverageCode { get; set; }

        
        public override int Quantity
        {
            get
            {
                return Sku.Quantity;
            }
            set
            {
                _quantity = value;
                Sku.Quantity = value;
            }
        }

        
        private string _cacheKey;

        private bool _isDirty = false;
        
        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        
        public bool IsInvalid { get; set; }

        
        public string SelectedFreightOption { get; set; }

        
        public Category FreightCategory { get; set; }

        
        public long LeadTimeDays { get; set; }

        
        public string DisruptiveReasonCode { get; set; }

        
        public long? ImpactQuantity { get; set; }

        public string ProductType
        {
            get
            {
                return (!IsTied) ?"NonTiedLineItemProductType" : string.Empty; 
                // return (!IsTied) ? CoreEx.Settings.Current.GetRegionalSettingValue<string>("NonTiedLineItemProductType") : string.Empty;
            }
        }

        public SolutionSkuItem()
        {
            Id = Guid.NewGuid();
            ItemType = ItemType.Sku;
            _sku = new SKU();
            Units = new List<Unit>();
           // TemplateRules = new List<TemplateRule>();
        }

        public string CacheKey
        {
            get
            {
                if (string.IsNullOrEmpty(_cacheKey))
                {
                    JObject o = JObject.FromObject(new
                    {
                        type = GetType().ToString(),
                        itemTypeCode = ItemTypeCode,
                        languageCode = Catalog.LanguageCode.Trim().ToUpper(),
                        catalogId = Catalog.Id
                    });

                    _cacheKey = o.ToString(0);
                }

                return _cacheKey;
            }
        }
    }
}
