
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
        
    public class Selection
    {
        private string _nodePathId;

        public Selection()
        {
            Attributes = new List<Attribute>();
            Skus = new List<SKU>();
        }

        
        public int ModuleId { get; set; }

        
        public string OptionId { get; set; }

        
        public List<SKU> Skus { get; set; }

        
        public List<Attribute> Attributes { get; set; }

        
        public int Quantity { get; set; }

        
        public string OptionDesc { get; set; }

        
        public bool IsModuleTied { get; set; }

        #region Fields Tobe Populated

        
        public long LeadTimeDays { get; set; }

        
        public bool IsInternalItem { get; set; }

        
        public SelectionType ModuleSelectionType { get; set; }

        
        public string RackInternalItemShapeName { get; set; }

        
        public Guid Id { get; set; }

        
        public bool IsConnected { get; set; }

        
        public bool IsNoneSelection { get; set; }

        #endregion

        
        public string NodePathId
        {
            get { return _nodePathId ?? string.Empty; }
            set { _nodePathId = value ?? string.Empty; }
        }

        
        public string StructureAttributes { get; set; }

        #region VI Fields
        
        public double? Duration { get; set; }

        public int DurationMonths => Duration.HasValue ? Convert.ToInt32(Math.Floor(Duration.Value)) : 0;
        #endregion

        
        public string AttributeMultiValues { get; set; }

        [Obsolete]
        public bool IsNonTied => (!IsModuleTied || HasCustomerKitSku);

        
        public bool IsFreightModule { get; set; }

        
        public bool IsCFISelection { get; set; }

        
        public string ModuleDesc { get; set; }

        
        public bool IsCFISkuForModuleValidation { get; set; }


        
        public bool HasEmbeddedConfig { get; set; }

        
        public List<Selection> EmbeddedConfigSelections { get; set; }

        
        public long? ImpactQuantity { get; set; }

        
        public List<SkuDPReasonCodeInfo> SkuDPReasonCodeInfoList { get; set; }

        
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

    
    
    public class SkuDPReasonCodeInfo
    {
        
        public string SkuNum { get; set; }

        
        public int? ImpactQuantity { get; set; }

        
        public string ReasonCode { get; set; }

        
        public SkuDPReasonCodePriority ReasonCodePriority { get; set; }
    }

}
