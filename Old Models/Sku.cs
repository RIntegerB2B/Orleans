using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
   [Serializable]
    [ProtoContract]
    public class SKU
    {
        [ProtoMember(1)]
        public string SkuNum { get; set; }

        [ProtoMember(2)]
        public string Description { get; set; }

        [ProtoMember(3)]
        public bool IsServiceSku { get; set; }

        [ProtoMember(4)]
        public bool IsCustomerKit { get; set; }

        [ProtoMember(5)]
        public string ItemTypeCode { get; set; }

        [ProtoMember(6)]
        public Pricing Price { get; set; }

        [ProtoMember(7)]
        public int Quantity { get; set; }

        [ProtoMember(8)]
        public bool IsSystemTied { get; set; }

        [ProtoMember(9)]
        public string ContractLaborCode { get; set; }

        #region Fields Tobe Populated

        [ProtoMember(10)]
        public string FulfillmentLocationId { get; set; }

        [ProtoMember(11)]
        public string ShipClass { get; set; }

        [ProtoMember(12)]
        public bool IsSelected { get; set; }

        [ProtoMember(13)]
        public string SkuModel { get; set; }

        [ProtoMember(14)]
        public Guid? BundleCode { get; set; }

        [ProtoMember(15)]
        public char Status { get; set; }

        [ProtoMember(16)]
        public string ParentChildAttribute { get; set; }

        [ProtoMember(17)]
        public string ClassCode { get; set; }

        [ProtoMember(18)]
        public VariableAspect VariableAspect { get; set; }

        [ProtoMember(19)]
        public int VariableItemGlobalIdentifier { get; set; }

        [ProtoMember(20)]
        public Guid Id { get; set; }

        [ProtoMember(21)]
        public string TaxClass { get; set; }

        #endregion

        [ProtoMember(22)]
        public string LineOfBusinessId { get; set; }

        [ProtoMember(23)]
        public string DiscountClassCode { get; set; }

        [ProtoMember(24)]
        public string ManufacturerId { get; set; }
    }
}
