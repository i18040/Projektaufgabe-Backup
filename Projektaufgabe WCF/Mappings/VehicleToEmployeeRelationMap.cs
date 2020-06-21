using FluentNHibernate.Mapping;

namespace Projektaufgabe_WCF.Mappings
{
    internal class VehicleToEmployeeRelationMap : ClassMap<VehicleToEmployeeRelation>
    {
        public VehicleToEmployeeRelationMap()
        {
            Table("VehicleToEmployeeRelation");

            Id(x => x.Id);
            Map(x => x.StartDate).Not.Nullable();
            Map(x => x.EndDate).Nullable();
            Map(x => x.VehicleId).Not.Nullable();
            Map(x => x.EmployeeId).Not.Nullable();
        }
    }
}