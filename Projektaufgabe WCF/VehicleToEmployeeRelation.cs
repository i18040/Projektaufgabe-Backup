using System;
using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class VehicleToEmployeeRelation : hasVersion
    {
        [DataMember] public int EmployeeId { get; set; }
        public new virtual int Version { get; set; }
        [DataMember] public virtual string Fullname { get; set; }
        [DataMember] public DateTime EndDate { get; set; }
        [DataMember] public DateTime StartDate { get; set; }
        [DataMember] public int VehicleId { get; set; }
    }
}