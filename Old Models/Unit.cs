using Dell.Solution.ItemApi.Model.Relationships;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
    [Serializable]
    [ProtoContract]
    public class Unit
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }

        #region Chassis info for Connector service

        [ProtoMember(2)]
        public List<PortInfo> OnBoardConnectors { get; set; }

        [ProtoMember(3)]
        public List<PortInfo> PortInfos { get; set; }

        [ProtoMember(4)]
        public List<Attribute> Attributes { get; set; }

        [ProtoMember(5)]
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
