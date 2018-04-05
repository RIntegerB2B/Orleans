
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dell.Solution.ItemApi.Model.Enum;

namespace Dell.Solution.ItemApi.Model.Relationships
{
    
    
    public class PortInfo
    {
        
        public int MaxPortCount;

        
        public int TotalPortCount { get; set; }

        
        public int AvailablePortCount { get; set; }

        
        public PortType PortType { get; set; }

        
        public bool IsMaleConnection { get; set; }

        
        public List<PortsSource> Origin { get; set; }

        public PortClass PortTypeClass
        {
            get { return PortType.PortClass; }
        }
    }
    
    
    public class PortType
    {
        
        public string PortTypeCode { get; set; }

        
        public string PortTypeName { get; set; }

        
        public PortClass PortClass { get; set; } //Same as PortTypeClass of connector service
    }
}
