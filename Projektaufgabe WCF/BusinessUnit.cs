using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class BusinessUnit : hasVersion
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string Description { get; set; }
    }
}