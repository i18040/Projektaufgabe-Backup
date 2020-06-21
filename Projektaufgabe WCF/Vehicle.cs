using System;
using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class Vehicle : hasVersion
    {
        [DataMember] public string LicensePlate { get; set; }
        [DataMember] public string Brand { get; set; }
        [DataMember] public string Model { get; set; }
        [DataMember] public decimal Insurance { get; set; }
        [DataMember] public DateTime LeasingFrom { get; set; }
        [DataMember] public DateTime LeasingTo { get; set; }
        [DataMember] public decimal LeasingRate { get; set; }
    }
}