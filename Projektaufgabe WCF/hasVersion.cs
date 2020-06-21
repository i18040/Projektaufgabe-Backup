using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class hasVersion
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public int Version { get; set; }
    }
}
