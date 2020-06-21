using System;
using System.Runtime.Serialization;
namespace Projektaufgabe_WCF
{
    [DataContract]
    public class MonthlyBusinessUnitCost
    {
        [DataMember] public DateTime Month { get; set; }

        [DataMember] public string BusinessUnitName { get; set; }

        [DataMember] public decimal Cost { get; set; }
    }
}