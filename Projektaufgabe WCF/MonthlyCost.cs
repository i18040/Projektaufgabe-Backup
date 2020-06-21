using System;
using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class MonthlyCost
    {
        [DataMember] public DateTime Month { get; set; }

        [DataMember] public int Count { get; set; }

        [DataMember] public decimal Cost { get; set; }
    }
}