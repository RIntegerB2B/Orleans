using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class SolutionConfigItem :SolutionItem
    {
        
        private string _cacheKey;

        
        public string OrderCodeId { get; set; }

        
        public string OrderCodeDescription { get; set; }

        
        public int ChassisId { get; set; }

        
        public string ChassisName { get; set; }

        
        public int FamilyId { get; set; }

        
        public List<Unit> Units { get; set; }

        
        public ProductType ProductType { get; set; }

        
        public List<Selection> Selections { get; set; }

        
        public bool IsRackable { get; set; }

        
        public string Language { get; set; }

        
        public string Country { get; set; }

        
        public Guid CacheId { get; set; }

        
        public long LeadTimeDays { get; set; }

        #region Non-serializable

        
        private byte[] _configRequest;

       
    
        //
        public dynamic ConfigRequest { get; set; }

        #endregion

        #region Properties

        public bool IsCloned
        {
            get { return (Quantity > 1); }
        }

        public override int Quantity
        {
            get { return Units == null ? 1 : Units.Count; }
        }

        #endregion

        #region Populated by Config Service Call

        
        private List<Category> _categories;

        public List<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new List<Category>();
                }
                return _categories;
            }
            set { _categories = value; }
        }


        //
        //public ThermalInfo ThermalInfo { get; set; }

        #endregion Populated by Config Service Call

        #region Non-Nullable

        
        public string SelectionXML { get; set; }

        
        public string CFICommentsXML { get; set; }

        
        public int NumOfProcessors { get; set; }

        #endregion

        
        public Guid ConnectivityToken { get; set; }

        
        public string ProductVariantCode { get; set; }

        
        public string Image { get; set; }

        
        public int ConfigImageSourceCode { get; set; }

        
        public string HeroImage { get; set; }

        
        public List<SolutionSkuItem> TiedSolutionSkuItems { get; set; }

        
        public string ImageUrl { get; set; }

        
        public SolutionConfigItem TemplateItem { get; set; }

        
        public Guid AdvisorTemplateProductId { get; set; }
        private bool _isDirty = false;
        
        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        
        public bool IsConnectable { get; set; }

        
        public bool HasConfigUpdated { get; set; }

        
        public bool HasConfigGoneEOL { get; set; }

        
        public string FamilyName { get; set; }

        
        public int BrandId { get; set; }

        
        public string BrandName { get; set; }

        
        public int ProductLineId { get; set; }

        
        public string ProductLineName { get; set; }

        public SolutionConfigItem RequestedSolutionConfigItem { get; set; }

        //
        //public CFI.CFIProject CFIProject { get; set; }

        
        public bool? IsPrimary { get; set; }

        
        public List<Attribute> Attributes { get; set; }

        
        public List<Selection> NoneSelections { get; set; }

        
        public string FreightSelectionXML { get; set; }

        
        public Category FreightCategory { get; set; }

        
        public int MultiplierQty { get; set; } = 1;


        //public bool HasXpodConfigChanged
        //{
        //    get { return IsXpodRequired && (HasOptionConfigChanged || HasConnectionConfigChanged); }
        //}

        public bool IsVariable()
        {
            return Categories.Where(category => category != null && category.Modules != null && category.Modules.Any()).Any(category => category.Modules.Any(module => module != null && module.IsVariable()));
        }

        public string BaseModuleOptionDescription
        {
            get
            {
                if (Selections != null)
                {
                    var selection = Selections.Find(sel => sel.ModuleId == 1);

                    return (selection != null ? selection.OptionDesc : string.Empty);
                }

                else
                    return string.Empty;
            }

        }

        public SKU BaseSku
        {
            get
            {
                if (Selections != null)
                {
                    //return Selections.SelectMany(s => s.Skus).FirstOrDefault(k => k.ItemTypeCode.Equals("2"));

                    foreach (var selection in Selections)
                    {
                        if (selection != null && selection.ModuleId == 1)
                        {
                            return selection.Skus.Find(sku => sku.ItemTypeCode.Equals("2"));
                        }
                    }
                }
                return null;
            }
        }

        public SolutionConfigItem()
        {
            Id = Guid.NewGuid();
            Units = new List<Unit>();
          //  TemplateRules = new List<TemplateRule>();

            ItemType = ItemType.Config;
            Selections = new List<Selection>();


            // default selection xml -> support for Dellstar
            SelectionXML = "<Selections></Selections>";
            // default cfi comments xml -> support for Dellstar
            CFICommentsXML = "<CFIComments></CFIComments>";
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
                        orderCodeId = OrderCodeId.ToLower(),
                        //customerSetId = Catalog.CustomerSet.Id, //Config is not using customerset any more in the cache DB. 
                        //chassisId = ChassisId,
                        languageCode = Catalog.LanguageCode.Trim().ToUpper(),
                        catalogId = Catalog.Id
                    });

                    _cacheKey = o.ToString(0);
                }

                return _cacheKey;
            }
        }

        public string Key
        {
            get { return this.CacheKey; }
        }

        private string _versionNumber;
        public string VersionNumber
        {
            get { return _versionNumber; }
            set { _versionNumber = value; }
        }

        //
        //public List<DiscountModel> Discounts { get; set; }

        
        public int ItemTrackingNbr { get; set; }

        
        public string EmcMaterialId { get; set; }

        
        public long? ImpactQuantity { get; set; }

        
        public List<SkuDPReasonCodeInfo> SkuDPReasonCodeInfoList { get; set; }

        //public string ManufacturerId
        //{
        //    get
        //    {
        //        return BaseSku != null ? BaseSku.ManufacturerId : string.Empty;
        //    }
        //    set
        //    {

        //    }
        //}

        public string BaseSkuLineOfBusinessId
        {
            get
            {
                return BaseSku != null ? BaseSku.LineOfBusinessId : string.Empty;
            }
        }


        public string BaseSkuClassCode
        {
            get
            {
                return BaseSku != null ? BaseSku.ClassCode : string.Empty;
            }
        }


        public List<string> DistinctDiscountClassCodes
        {
            get
            {
                List<string> classCodes = new List<string>();
                if (Selections != null)
                {
                    //return Selections.SelectMany(s => s.Skus).FirstOrDefault(k => k.ItemTypeCode.Equals("2"));
                    classCodes = Selections.SelectMany(s => s.Skus).Where(sku => sku.DiscountClassCode != null && sku.DiscountClassCode.Trim() != "").Select(sku => sku.DiscountClassCode).Distinct().ToList();
                }
                return classCodes;
            }
        }

        
        public bool HasEmbeddedConfig { get; set; }


        
        [XmlIgnore]
        public SolutionConfigItem ParentConfigItem { get; set; }

        
        public bool IsComplexGroupItem { get; set; }

        public bool CheckForEmbeddedConfigs
        {
            get { return Selections.Any(sel => sel.HasEmbeddedConfig); }
        }

        
        public bool IsConfigComposite { get; set; }

        
        public List<Selection> EolNonTiedSelections { get; set; }
    }
}
