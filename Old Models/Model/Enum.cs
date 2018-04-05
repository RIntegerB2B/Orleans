using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
    public class Enum
    {
        public enum CustomerSetType
        {
            Transactional = 1,
            Premier = 2
        }
        public enum ItemType
        {
            Config = 0,
            Sku = 1,
            Subscription = 2,
            Chassis = 3,
            ComplexItem = 4
        }
        public enum AttributeType
        {
            None,
            String,
            Float,
            Bool,
            SolutionReferenceArchitecture
        }
        public enum ProductType
        {
            Server,
            HBA,
            FiberChannelSwitch,
            DPE,
            DAE,
            Rack,
            Group,
            EthernetRackSwitch,
            TapeBackup,
            KVM,
            Blade,
            BladeServerEnclosure,
            Cluster,
            ValidationGroup,
            NAS,
            Upgrades,
            BladeSwitch,
            None,
            DiskArray,
            All,
            NIC,
            MultiPackShippingContainer,
            Desktop,
            Notebook,
            Software,
            InfiniBandSwitch,
            InfinibandHCA,
            Services,
            DiskBackup,
            EqualLogic,
            DataCenterSolutions,
            APOS,
            FlexComputing,
            Workstation,
            EthernetChassisSwitch,
            StandardConfigProduct = 1000,
            FullCatalogProduct,
            VelocityService,
            UnifiedStorage,
            ObjectStorage,
            Storage = 2000
        }
        [System.Serializable]
        public enum LineItemSource
        {
            Freehand,
            CustomServiceInitial,
            CustomServiceExtended,
            CustomServiceStandardInitial,
            CustomServiceStandardExtended,
            Cable,
            DefaultService,
            CFI,
            Internal,
            CFIOptional,
            SoftwareAndAccessories,
            Compellent,
            ComplexItem
        }
        [System.Serializable]
        public enum UserAction
        {
            None = 0,
            AddToItem = 1,
            AddToSolution = 2,
            AddToComplexItem = 3
        }

        public enum SelectionType
        {
            Single = 0,
            MultiSelect = 1,
        }
        [System.Serializable]
        public enum FilterType
        {
            Disable = 0,
            Hide = 1,
            Show = 2,
            Undefined = 3
        }
        public enum OptionGroupType
        {
            /// <remarks/>
            M,

            /// <remarks/>
            O,

            /// <remarks/>
            MA,

            /// <remarks/>
            OA,

            /// <remarks/>
            Unknown,

        }
        [System.Serializable]
        public enum SkuDPReasonCodePriority
        {
            [System.ComponentModel.Description("New Product Launch Planning")]
            NewProductLaunchPlanning = 1,
            [System.ComponentModel.Description("Material countdown")]
            MaterialCountdown = 2,
            [System.ComponentModel.Description("Low qty planner")]
            LowQtyPlanner = 3,
            [System.ComponentModel.Description("Low qty planned")]
            LowQtyPlanned = 4,
            [System.ComponentModel.Description("President level allocation")]
            PresidentLevelAllocation = 5,
            [System.ComponentModel.Description("Unplanned ReasonCode")]
            Default = 6,
        }

        [System.Serializable]
        public enum DiscountType
        {
            None,
            Margin,
            Discount,
            TotalPrice,
            GEMDiscount
        }
        [System.Serializable]
        public enum PortsSource
        {
            Chassis,
            Option
        }

        [System.Serializable]
        public enum PortClass
        {
            NONE,
            CARD_SLOT,
            RACK_SLOT,
            BLADE_SLOT,
            BLADE_SWITCH_SLOT,
            CONNECTOR,
            ETHERNET_CABLE,
            FIBRE_CHANNEL_CABLE,
            SCSI_CABLE,
            SAS_CABLE,
            INFINIBAND_CABLE,
            CLOUD,
            NAS,
            VRTX,
            SFP,
            SFPPLUS,
            QSFPPLUS,
            SW_ASM
        }
        [System.Serializable]
        public enum RuleType    //TemplateRuleEnum in DellStarServer app
        {
            None = 0,
            LockedModule = 1,   //applied at Module level
            UpsellOnly = 2,     //applied at Module level
            LockedConfig = 3,   //applied at the Solution config
            HideModule = 4,     //applied at Module level
            HideAllModules = 5,     //applied at SolutionItem level (config)
            HideAllOptions = 6, //applied at Module level
            HideOption = 7,     //applied at the Option level
            RestrictQtyChange = 100,    //applied at SolutionItem level (config & SKU)
            Required = 101  ////applied at SolutionItem level (config & SKU)
        }

    }
}
