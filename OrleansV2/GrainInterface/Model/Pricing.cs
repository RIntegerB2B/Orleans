
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class Pricing : ICloneable
    {
        
        public double ContractPrice { get; set; }

        /// <summary>
        /// Actual Cost of the Item..
        /// From Config: If BestCost is Greater than Zero OR
        /// If CompensationCost is Less than or each to Zero
        /// And FPCCost is Greater than Zero, then FPCCost or UnitCost
        /// </summary>
        
        public double Cost { get; set; }

        /// <summary>
        /// List Price
        /// </summary>
        
        public double ListPrice { get; set; }

        /// <summary>
        /// Retail or Market Price
        /// </summary>
        
        public double RetailPrice { get; set; }

        /// <summary>
        /// Offered Price in the Market.. 
        /// If not then Contract Price.. 
        /// If not then Standard Price..
        /// If not then it will be Retail Price..
        /// </summary>
        
        public double OfferPrice { get; set; }

        /// <summary>
        /// Sale Price
        /// </summary>
        
        public double SalePrice { get; set; }

        /// <summary>
        /// From Config: DeltaRetailPrice
        /// </summary>
        
        public double DeltaRetailPrice { get; set; }

        /// <summary>
        /// From Config: DeltaOfferPrice
        /// </summary>
        
        public double DeltaOfferPrice { get; set; }

        /// <summary>
        /// From Config: DeltaPrice
        /// </summary>
        
        public double DeltaPrice { get; set; }

        /// <summary>
        /// Calculated: RetailPrice * Quantity
        /// </summary>
        
        public double TotalPrice { get; set; }

        /// <summary>
        /// Calculated: RetailPrice - SalePrice
        /// </summary>
        
        public double Discount { get; set; }

        /// <summary>
        /// From Db: SolutionQuoteGroup.QuoteGroupPricing_xml
        /// </summary>
        
        public DiscountType LastDiscountType { get; set; }

        /// <summary>
        /// From Db: SolutionQuoteGroup.QuoteGroupPricing_xml
        /// </summary>
        
        public double LastDiscountAmount { get; set; }

        /// <summary>
        /// Calculated: (RetailPrice - Cost)/RetailPrice
        /// </summary>
        
        public double MarginPercent { get; set; }

        /// <summary>
        /// Calculated: (SalePrice - Discount)/SalePrice
        /// </summary>
        
        public double DiscountPercent { get; set; }

        /// <summary>
        /// To make it compatible with dellstar
        /// </summary>
        //
        //public List<SkuOfferPrice> DellStarSkuOfferPriceList { get; set; }

        /// <summary>
        /// Calculated: SalePrice - Discount
        /// </summary>
        
        public double DiscountedPrice { get; set; }

        /// <summary>
        /// Calculated: RetailPrice - Cost
        /// </summary>
        
        public double MarginPrice { get; set; }

        /// <summary>
        /// Calculated: OfferPrice - NonTiedModuleOfferPrice
        /// </summary>
        
        public double ModuleOfferPrice { get; set; }


        /// <summary>
        /// ItemLevelDisCountedPrice: NonTiedModulePrice+DiscountedPrice
        /// </summary>
        
        public double ItemLevelDiscountedPrice { get; set; }

        /// <summary>
        /// ItemLevelDisCountedPrice: NonTiedModulePrice+DiscountedPrice
        /// </summary>
        
        public string DisplayCurrencyCode { get; set; }

        /// <summary>
        /// OverridePriceFlag: if the price from config needs to be overridden by client, this needs to be set to true
        /// </summary>
        
        public bool ShowOverridePrice { get; set; }

        /// <summary>
        /// OverridePrice: if the price from config needs to be overridden by client, client will pass this value which will override the list price
        /// </summary>
        
        public double OverridePrice { get; set; }

        /// <summary>
        /// Calculated: DiscountedPrice - nontiedModulePrice
        /// </summary>
        
        public double ModuleDiscountedPrice { get; set; }



        /// <summary>
        /// Hardware and Software price
        /// </summary>
        
        public double HardwareAndSoftwarePrice { get; set; }

        /// <summary>
        /// Service price
        /// </summary>
        
        public double ServicePrice { get; set; }


        #region ICloneable interface implemenation

        public object Clone()
        {
            return new Pricing
            {
                ContractPrice = ContractPrice,
                Cost = Cost,
                ListPrice = ListPrice,
                RetailPrice = RetailPrice,
                OfferPrice = OfferPrice,
                SalePrice = SalePrice,
                DeltaRetailPrice = DeltaRetailPrice,
                DeltaOfferPrice = DeltaOfferPrice,
                DeltaPrice = DeltaPrice,
                TotalPrice = TotalPrice,
                Discount = Discount,
                LastDiscountType = LastDiscountType,
                LastDiscountAmount = LastDiscountAmount,
                MarginPercent = MarginPercent,
                DiscountPercent = DiscountPercent,
                DiscountedPrice = DiscountedPrice,
                MarginPrice = MarginPrice,
                ModuleOfferPrice = ModuleOfferPrice,
                ItemLevelDiscountedPrice = ItemLevelDiscountedPrice,
                DisplayCurrencyCode = DisplayCurrencyCode,
                ShowOverridePrice = ShowOverridePrice,
                OverridePrice = OverridePrice,
                HardwareAndSoftwarePrice = HardwareAndSoftwarePrice,
                ServicePrice = ServicePrice
                //DellStarSkuOfferPriceList = DellStarSkuOfferPriceList != null ? DellStarSkuOfferPriceList.Select(sop => (SkuOfferPrice)sop.Clone()).ToList() : null
            };
        }

        #endregion
    }
}
