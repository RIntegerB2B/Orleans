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
    public class Selection
    {
        private string _nodePathId;

        public Selection()
        {
            Attributes = new List<Attribute>();
            Skus = new List<SKU>();
        }

        [ProtoMember(1)]
        public int ModuleId { get; set; }

        [ProtoMember(2)]
        public string OptionId { get; set; }

        [ProtoMember(3)]
        public List<SKU> Skus { get; set; }

        [ProtoMember(4)]
        public List<Attribute> Attributes { get; set; }

        [ProtoMember(5)]
        public int Quantity { get; set; }

        [ProtoMember(6)]
        public string OptionDesc { get; set; }

        [ProtoMember(7)]
        public bool IsModuleTied { get; set; }

        #region Fields Tobe Populated

        [ProtoMember(8)]
        public long LeadTimeDays { get; set; }

        [ProtoMember(9)]
        public bool IsInternalItem { get; set; }

        [ProtoMember(10)]
        public SelectionType ModuleSelectionType { get; set; }

        [ProtoMember(11)]
        public string RackInternalItemShapeName { get; set; }

        [ProtoMember(12)]
        public Guid Id { get; set; }

        [ProtoMember(13)]
        public bool IsConnected { get; set; }

        [ProtoMember(14)]
        public bool IsNoneSelection { get; set; }

        #endregion

        [ProtoMember(15)]
        public string NodePathId
        {
            get { return _nodePathId ?? string.Empty; }
            set { _nodePathId = value ?? string.Empty; }
        }

        [ProtoMember(16)]
        public string StructureAttributes { get; set; }

        #region VI Fields
        [ProtoMember(17)]
        public double? Duration { get; set; }

        public int DurationMonths => Duration.HasValue ? Convert.ToInt32(Math.Floor(Duration.Value)) : 0;
        #endregion

        [ProtoMember(18)]
        public string AttributeMultiValues { get; set; }

        [Obsolete]
        public bool IsNonTied => (!IsModuleTied || HasCustomerKitSku);

        [ProtoMember(19)]
        public bool IsFreightModule { get; set; }

        [ProtoMember(20)]
        public bool IsCFISelection { get; set; }

        [ProtoMember(21)]
        public string ModuleDesc { get; set; }

        [ProtoMember(22)]
        public bool IsCFISkuForModuleValidation { get; set; }


        [ProtoMember(23)]
        public bool HasEmbeddedConfig { get; set; }

        [ProtoMember(24)]
        public List<Selection> EmbeddedConfigSelections { get; set; }

        [ProtoMember(25)]
        public long? ImpactQuantity { get; set; }

        [ProtoMember(26)]
        public List<SkuDPReasonCodeInfo> SkuDPReasonCodeInfoList { get; set; }

        [ProtoMember(28)]
        public SolutionConfigItem EmbeddedConfigItem { get; set; }


        private bool HasCustomerKitSku
        {
            get { return Skus.Any(sku => sku.IsCustomerKit); }
        }

        public IEnumerable<Guid> DistinctSkuIds
        {
            get { return Skus.Select(i => i.Id).Distinct(); }
        }
    }

    [Serializable]
    [ProtoContract]
    public class SkuDPReasonCodeInfo
    {
        [ProtoMember(1)]
        public string SkuNum { get; set; }

        [ProtoMember(2)]
        public int? ImpactQuantity { get; set; }

        [ProtoMember(3)]
        public string ReasonCode { get; set; }

        [ProtoMember(4)]
        public SkuDPReasonCodePriority ReasonCodePriority { get; set; }
    }

}
