using Dell.Solution.ItemApi.Model.Relationships;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
    
    
    public class Unit
    {
        
        public Guid Id { get; set; }

        #region Chassis info for Connector service

        
        public List<PortInfo> OnBoardConnectors { get; set; }

        
        public List<PortInfo> PortInfos { get; set; }

        
        public List<Attribute> Attributes { get; set; }

        
        public List<PortInfo> TotalPortInfos { get; set; }

        public Unit()
        {
            OnBoardConnectors = new List<PortInfo>();
            PortInfos = new List<PortInfo>();
            Attributes = new List<Attribute>();
            TotalPortInfos = new List<PortInfo>();
        }

        #endregion Chassis info for Connector service
    }
}
