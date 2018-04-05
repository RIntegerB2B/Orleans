using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
    [Serializable]
    [ProtoContract]
    public class Category
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public List<Module> Modules { get; set; }

        [ProtoMember(4)]
        public int Sequence { get; set; }

        [ProtoMember(5)]
        public string OrderInstructions { get; set; }
    }
}
