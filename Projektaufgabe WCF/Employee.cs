using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class Employee
    {
        [DataMember] public int Id { get; set; }
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
        [DataMember] public int Version { get; set; }
    }
}