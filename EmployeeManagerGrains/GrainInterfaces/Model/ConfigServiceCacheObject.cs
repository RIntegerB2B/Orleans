
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    public class ConfigServiceCacheObject
    {
        
        public class CacheContainer
        {
            
            public CachedOrderCode OrderCode { get; set; }
        }

        
        public class CachedOrderCode
        {
            //
            //private string _cacheKey;

            
            public string OrderCodeId { get; set; }

            
            public string OrderCodeDescription { get; set; }

            
            public int ChassisId { get; set; }

            
            public string ChassisName { get; set; }

            
            public int FamilyId { get; set; }

            
            public ProductType ProductType { get; set; }

            //
            //public List<Attribute> Attributes { get; set; }

        }
    }
}
