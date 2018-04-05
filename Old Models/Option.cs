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
    [System.Diagnostics.DebuggerDisplay("OptionId={OptionId}")]
    public class Option 
    {
        [ProtoMember(1)]
        public string OptionId { get; set; }

        [ProtoMember(2)]
        public string Description { get; set; }

        [ProtoMember(3)]
        public int Quantity { get; set; }

        [ProtoMember(4)]
        public bool IsMultiQtyAllowed { get; set; }

        [ProtoMember(5)]
        public bool IsSelected { get; set; }

        [ProtoMember(6)]
        public bool IsDefault { get; set; }

        [ProtoMember(7)]
        public bool IsVisible { get; set; }

        [ProtoMember(8)]
        public bool IsNoneOption { get; set; }

        [ProtoMember(9)]
        public List<SKU> Skus { get; set; }

        [ProtoMember(10)]
        public List<Attribute> Attributes { get; set; }

        [ProtoMember(11)]
        public Pricing Price { get; set; }

        [ProtoMember(12)]
        public FilterType FilterType { get; set; }

        [ProtoMember(13)]
        public bool HiddenByTemplateRule { get; set; }

        [ProtoMember(14)]
        public string NodePathId { get; set; }

        [ProtoMember(15)]
        public string StructureAttributes { get; set; }

        [ProtoMember(16)]
        public bool IsDisabled { get; set; }

        [ProtoMember(17)]
        public long LeadTimeDays { get; set; }

        [ProtoMember(18)]
        public string AttributeMultiValues { get; set; }

        [ProtoMember(19)]
        public VariableAspect VariableAspect { get; set; }

        [ProtoMember(20)]
        public string OrderInstructions { get; set; }

        [ProtoMember(21)]
        public List<int> GiiOnlineModuleIds { get; set; }

        [ProtoMember(22)]
        public int? GiiValidationModuleId { get; set; }

        [ProtoMember(23)]
        public bool GiiRemoveExistingSelection { get; set; }

        [ProtoMember(24)]
        public SolutionConfigItem EmbeddedConfigItem { get; set; }

        [ProtoMember(25)]
        public long? ImpactQuantity { get; set; }

        [ProtoMember(26)]
        public List<SkuDPReasonCodeInfo> SkuDPReasonCodeInfoList { get; set; }

        [ProtoMember(27)]
        public bool HasEmbeddedConfig { get; set; }

        [ProtoMember(28)]
        public Pricing DefaultPrice { get; set; }

        [ProtoMember(29)]
        public bool VPEnabled { get; set; }

        public TClone Clone<TClone>() where TClone : Option
        {
            return (TClone)MemberwiseClone();
        }
        public string RetrieveDurationDisplay(string monthsLabel, int months)
        {
            string durationDisplayLabel = string.Empty;

            if (VariableAspect != null && months > 0)
            {
                durationDisplayLabel = "[" + months + ' ' + monthsLabel + "]";
            }

            return durationDisplayLabel;
        }

    }
}
