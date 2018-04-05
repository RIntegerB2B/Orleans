using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    [System.Serializable]
    [ProtoContract]
    public class SolutionCatalog
    {
        public SolutionCatalog()
        {
            CustomerSet = new CustomerSet();
        }

        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public int CompanyNumber { get; set; }

        [ProtoMember(3)]
        public CustomerSet CustomerSet { get; set; }

        [ProtoMember(4)]
        public string LanguageCode { get; set; }

        [ProtoMember(5)]
        public int LanguageId { get; set; }

        [ProtoMember(6)]
        public string CurrencyCode { get; set; }

        [ProtoMember(7)]
        public string CountryCode { get; set; }

        [ProtoMember(8)]
        public int BusinessUnitId { get; set; }
        //public string Region { get; set; }

        [ProtoMember(9)]
        public string DefaultLanguage { get; set; }

        [ProtoMember(10)]
        public string DefaultCultureInfoName { get; set; }

        [ProtoMember(11)]
        public string DefaultSolutionCustomerSet { get; set; }

        [ProtoMember(12)]
        public string Name { get; set; }

        [ProtoMember(13)]
        public string Description { get; set; }

        [ProtoMember(14)]
        public string DisplayCountryCode { get; set; }

        [ProtoMember(15)]
        public int CustomerTypeId { get; set; }

        [ProtoMember(16)]
        public int SnaCatalogId { get; set; }

        [ProtoMember(17)]
        public long? OrgId { get; set; }
    }

    [ProtoContract]
    public class CustomerSet 
    {
      //  public CustomerSet();

        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public CustomerSetType Type { get; set; }
        public string CacheKey { get; }
    }
}
