using Newtonsoft.Json.Linq;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    [Serializable]
    [ProtoContract]
    public class SolutionSkuItem : SolutionItem
    {
        [ProtoMember(1)]
        private SKU _sku;

        [ProtoMember(2)]
        private int _quantity;

        [ProtoMember(3)]
        public LineItemSource Source { get; set; }

        [ProtoMember(4)]
        public bool IsTied { get; set; }

        [ProtoMember(5)]
        public Guid ParentId { get; set; }

        [ProtoMember(6)]
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

        [ProtoMember(7)]
        public UserAction Action { get; set; }

        [ProtoMember(8)]
        public bool PassedBusinessRules { get; set; }

        [ProtoMember(9)]
        public string ContractLaborCode { get; set; }

        [ProtoMember(10)]
        public string ItemTypeCode { get; set; }

        [ProtoMember(11)]
        public int CoverageCode { get; set; }

        [ProtoMember(12)]
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

        [ProtoMember(13)]
        private string _cacheKey;

        private bool _isDirty = false;
        [ProtoMember(14)]
        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        [ProtoMember(15)]
        public bool IsInvalid { get; set; }

        [ProtoMember(16)]
        public string SelectedFreightOption { get; set; }

        [ProtoMember(17)]
        public Category FreightCategory { get; set; }

        [ProtoMember(18)]
        public long LeadTimeDays { get; set; }

        [ProtoMember(19)]
        public string DisruptiveReasonCode { get; set; }

        [ProtoMember(20)]
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
