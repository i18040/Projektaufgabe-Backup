using FluentNHibernate.Mapping;

namespace Projektaufgabe_WCF.Mappings
{
    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Id(x => x.Id);
            Map(x => x.Username).Length(20).Unique().Not.Nullable();
            Map(x => x.Firstname).Length(50);
            Map(x => x.Lastname).Length(50).Not.Nullable();
            Map(x => x.Password).Length(60).Not.Nullable();
            Map(x => x.isAdmin).Not.Nullable();
            Map(x => x.Version).Not.Nullable();
        }
    }
}