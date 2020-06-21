using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class Employee : hasVersion
    {
        [DataMember] public string Firstname { get; set; }
        [DataMember] public string Lastname { get; set; }
        [DataMember] public int EmployeeNumber { get; set; }
        [DataMember] public string Salutation { get; set; }
        [DataMember] public string Title { get; set; }

        [DataMember]
        public virtual string Fullname
        {
            get => Title + " " + Firstname + " " + Lastname;
        }
        [DataMember] public int BusinessUnitId { get; set; }
        [DataMember] public virtual string BusinessUnit { get; set; }
    }
}