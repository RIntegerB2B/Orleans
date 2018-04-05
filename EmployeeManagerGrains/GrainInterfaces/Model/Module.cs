
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
    
    [System.Diagnostics.DebuggerDisplay("ModuleId={ModuleId}")]
    public class Module
    {
        
        public int ModuleId { get; set; }

        
        public string Description { get; set; }

        
        public bool IsRequired { get; set; }

        
        public bool IsMultiSelect { get; set; }

        
        public bool IsTied { get; set; }

        
        public int Sequence { get; set; }

        
        public int Quantity { get; set; }

        
        public Pricing Price { get; set; }

        
        public List<Option> Options { get; set; }

        
        public bool IsFlavoredDriver { get; set; }

        
        public string LearnMoreUrl { get; set; }

        
        public bool IsServiceModule { get; set; }

        
        public bool IsVisible { get; set; }

        
        public RuleType TemplateRuleType { get; set; }

        
        public bool HiddenByTemplateRule { get; set; }

        
        public string StructureAttributes { get; set; }

        
        public string YearsLabel { get; set; }

        
        public string MonthsLabel { get; set; }

        
        public string DaysLabel { get; set; }

        
        public bool IsFreightModule { get; set; }

        
        public bool IsCFIModule { get; set; }

        
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
        
        public OptionGroupType OptionGroupType
        {
            get;
            set;
        }

        
        public string ModuleKey { get; set; }

        
        public bool IsCompositeConfigModule { get; set; }

    }

    
}
