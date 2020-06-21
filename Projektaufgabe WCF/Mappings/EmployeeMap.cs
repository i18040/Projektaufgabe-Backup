using FluentNHibernate.Mapping;

namespace Projektaufgabe_WCF.Mappings
{
    internal class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");

            Id(x => x.Id);
            Map(x => x.Firstname).Length(50);
            Map(x => x.Lastname).Length(50).Not.Nullable();
            Map(x => x.EmployeeNumber).Unique().Not.Nullable();
            Map(x => x.Salutation).Length(50).Nullable();
            Map(x => x.Title).Length(50).Nullable();
            Map(x => x.BusinessUnitId).Not.Nullable();
            Map(x => x.Version).Not.Nullable();
        }
    }
}