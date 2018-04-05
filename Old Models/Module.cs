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
    [System.Diagnostics.DebuggerDisplay("ModuleId={ModuleId}")]
    public class Module
    {
        [ProtoMember(1)]
        public int ModuleId { get; set; }

        [ProtoMember(2)]
        public string Description { get; set; }

        [ProtoMember(3)]
        public bool IsRequired { get; set; }

        [ProtoMember(4)]
        public bool IsMultiSelect { get; set; }

        [ProtoMember(5)]
        public bool IsTied { get; set; }

        [ProtoMember(6)]
        public int Sequence { get; set; }

        [ProtoMember(7)]
        public int Quantity { get; set; }

        [ProtoMember(8)]
        public Pricing Price { get; set; }

        [ProtoMember(9)]
        public List<Option> Options { get; set; }

        [ProtoMember(10)]
        public bool IsFlavoredDriver { get; set; }

        [ProtoMember(11)]
        public string LearnMoreUrl { get; set; }

        [ProtoMember(12)]
        public bool IsServiceModule { get; set; }

        [ProtoMember(13)]
        public bool IsVisible { get; set; }

        [ProtoMember(14)]
        public RuleType TemplateRuleType { get; set; }

        [ProtoMember(15)]
        public bool HiddenByTemplateRule { get; set; }

        [ProtoMember(16)]
        public string StructureAttributes { get; set; }

        [ProtoMember(17)]
        public string YearsLabel { get; set; }

        [ProtoMember(18)]
        public string MonthsLabel { get; set; }

        [ProtoMember(19)]
        public string DaysLabel { get; set; }

        [ProtoMember(20)]
        public bool IsFreightModule { get; set; }

        [ProtoMember(21)]
        public bool IsCFIModule { get; set; }

        [ProtoMember(22)]
        public string OrderInstructions { get; set; }

        public bool IsVariable()
        {
            return Options.Any(option => option?.VariableAspect != null);
        }

        public TClone Clone<TClone>() where TClone : Module
        {
            var moduleClone = (TClone)MemberwiseClone();
            moduleClone.Options = Options.ConvertAll(o => o.Clone<Option>());
            return moduleClone;
        }
        [ProtoMember(23)]
        public OptionGroupType OptionGroupType
        {
            get;
            set;
        }

        [ProtoMember(24)]
        public string ModuleKey { get; set; }

        [ProtoMember(25)]
        public bool IsCompositeConfigModule { get; set; }

    }

    
}
