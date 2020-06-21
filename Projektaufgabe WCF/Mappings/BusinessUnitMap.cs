using FluentNHibernate.Mapping;

namespace Projektaufgabe_WCF.Mappings
{
    internal class BusinessUnitMap : ClassMap<BusinessUnit>
    {
        public BusinessUnitMap()
        {
            Table("BusinessUnits");

            Id(x => x.Id);
            Map(x => x.Name).Length(100).Not.Nullable();
            Map(x => x.Description).Length(250).Nullable();
            Map(x => x.Version).Not.Nullable();
        }
    }
}