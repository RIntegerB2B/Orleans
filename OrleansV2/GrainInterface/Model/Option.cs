
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class Option 
    {
        
        public string OptionId { get; set; }

        
        public string Description { get; set; }

        
        public int Quantity { get; set; }

        
        public bool IsMultiQtyAllowed { get; set; }

        
        public bool IsSelected { get; set; }

        
        public bool IsDefault { get; set; }

        
        public bool IsVisible { get; set; }

        
        public bool IsNoneOption { get; set; }

        
        public List<SKU> Skus { get; set; }

        
        public List<Attribute> Attributes { get; set; }

        
        public Pricing Price { get; set; }

        
        public FilterType FilterType { get; set; }

        
        public bool HiddenByTemplateRule { get; set; }

        
        public string NodePathId { get; set; }

        
        public string StructureAttributes { get; set; }

        
        public bool IsDisabled { get; set; }

        
        public long LeadTimeDays { get; set; }

        
        public string AttributeMultiValues { get; set; }

        
        public VariableAspect VariableAspect { get; set; }

        
        public string OrderInstructions { get; set; }

        
        public List<int> GiiOnlineModuleIds { get; set; }

        
        public int? GiiValidationModuleId { get; set; }

        
        public bool GiiRemoveExistingSelection { get; set; }

        
        public SolutionConfigItem EmbeddedConfigItem { get; set; }

        
        public long? ImpactQuantity { get; set; }

        
        public List<SkuDPReasonCodeInfo> SkuDPReasonCodeInfoList { get; set; }

        
        public bool HasEmbeddedConfig { get; set; }

        
        public Pricing DefaultPrice { get; set; }

        
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
