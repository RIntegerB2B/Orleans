using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    public abstract class SolutionItem
    {
       
        public Guid Id { get; set; }

        
        public string Description { get; set; }

        
        public ItemType ItemType { get; set; }

        
        public virtual int Quantity { get; set; }

        
        public Pricing Price { get; set; }

        
        public SolutionCatalog Catalog { get; set; }

        
        public bool IsSelected { get; set; }

        
        
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

        

        protected SolutionItem() { }

        

        public string UniqueKey
        {
            get { return this.GetType().ToString() + "-" + this.Id.ToString(); }
            set
            {
                //must have setter for xml serialization
            }
        }

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
