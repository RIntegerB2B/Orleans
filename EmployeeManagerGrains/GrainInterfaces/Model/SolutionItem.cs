
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
  
   // [XmlInclude(typeof(SolutionSkuItem))]
   // [XmlInclude(typeof(SolutionProjectItem))]
   // [XmlInclude(typeof(SolutionComplexItem))]
    
    
  //  [ProtoInclude(101, typeof(SolutionSkuItem))]
  //  [ProtoInclude(102, typeof(SolutionProjectItem))]
  //  [ProtoInclude(103, typeof(SolutionComplexItem))]
    public abstract class SolutionItem
    {
        
        public Guid Id { get; set; }

        
        public string Description { get; set; }

        
        public ItemType ItemType { get; set; }

        
        public virtual int Quantity { get; set; }

        
        public Pricing Price { get; set; }

        
        public SolutionCatalog Catalog { get; set; }

        
        public bool IsSelected { get; set; }

        //
        //public List<Message> Messages { get; set; }

        //
        //public List<SalesComment> SalesComments { get; set; }

        //
        //public List<TemplateRule> TemplateRules { get; set; }

        //private List<Delta> _deltas = null;
        //
        //public List<Delta> Deltas
        //{
        //    get
        //    {
        //        if (_deltas == null)
        //            _deltas = new List<Model.Solutions.Delta>();

        //        return _deltas;
        //    }
        //    set
        //    {
        //        _deltas = value;
        //    }
        //}

        //public virtual void ClearDeltas()
        //{
        //    if (_deltas != null)
        //        _deltas.Clear();
        //}

        
        public bool IsConnected { get; set; }

        
        public int SequenceNumber { get; set; }

        
        public bool IsXpodRequired { get; set; }

        
        public bool HasConfigChanged { get; set; }

        
        public bool IsTemplateItem { get; set; }

        
        public bool PauseQuote { get; set; }

        
        public bool HasOptionConfigChanged { get; set; }

        
        public bool HasConnectionConfigChanged { get; set; }

        
        public bool CfiAdminOverride { get; set; }

        
        public string ConfigurationType { get; set; }

        /*[ProtoIgnore]
        [XmlIgnore]
        public virtual List<Delta> AggregatedDeltas
        {
            get { return Deltas ?? new List<Delta>(); }
        }*/

        protected SolutionItem() { }

        //public bool IsRequired
        //{
        //    get
        //    {
        //        return (this.TemplateRules.Any(rule => rule.Rule == RuleType.Required));
        //    }
        //}

        //public bool IsRestrictedQty
        //{
        //    get
        //    {
        //        return (this.TemplateRules.Any(rule => rule.Rule == RuleType.RestrictQtyChange));
        //    }
        //}

        [XmlAttribute(AttributeName = "UniqueKey")]
        public string UniqueKey
        {
            get { return this.GetType().ToString() + "-" + this.Id.ToString(); }
            set
            {
                //must have setter for xml serialization
            }
        }

        [XmlAttribute(AttributeName = "ObjectId")]
        public string ObjectId
        {
            get { return this.GetType().ToString() + "-" + this.Id.ToString(); }
            set
            {
                //must have for xml serialization
            }
        }

        
        public string OSC_DSA_Qty { get; set; }

        
        public List<KeyValuePair<int, string>> EmbeddedConfigModules { get; set; }

        
        public bool IsDPDataAvailable { get; set; }

        
        public Pricing DefaultPrice { get; set; }

        
        public bool VPEnabled { get; set; }

    }
}
