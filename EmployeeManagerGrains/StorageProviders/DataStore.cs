using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StorageProviders
{
    public class DataStore
    {
        [DataMember(Name = "Key")]
        public string Key;
        [DataMember(Name = "Value")]
        public string Value;
    }
}
