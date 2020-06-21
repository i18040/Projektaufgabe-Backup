using System.Runtime.Serialization;

namespace Projektaufgabe_WCF
{
    [DataContract]
    public class User : hasVersion
    {
        [DataMember] public string Username { get; set; }
        [DataMember] public string Firstname { get; set; }
        [DataMember] public string Lastname { get; set; }
        [DataMember] public string Password { get; set; }
        [DataMember] public bool isAdmin { get; set; }
    }
}