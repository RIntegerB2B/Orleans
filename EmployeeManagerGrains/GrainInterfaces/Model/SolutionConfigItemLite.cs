using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    public class SolutionConfigItemLite
    {
        public string OrderCodeId { get; set; }

       public string OrderCodeDescription { get; set; }

        public int ChassisId { get; set; }

       public string ChassisName { get; set; }

        public int FamilyId { get; set; }
        public ItemType ItemType { get; set; }

        public ProductType ProductType { get; set; }

        public int Quantity { get; set; }

         public bool IsRackable { get; set; }

         public List<Attribute> Attributes { get; set; }

       public bool IsXpodRequired { get; set; }

      public bool PauseQuote { get; set; }

        public bool IsConnectable { get; set; }

        public string FamilyName { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }

    public class Attribute
    {       
        public string Name { get; set; }
        
        public string StringValue { get; set; }
        
        public float NumericValue { get; set; }
      
        public AttributeType AttributeType { get; set; }
    }
}
