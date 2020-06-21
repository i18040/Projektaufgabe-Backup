using FluentNHibernate.Mapping;

namespace Projektaufgabe_WCF.Mappings
{
    internal class VehicleMap : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Table("Vehicles");

            Id(x => x.Id);
            Map(x => x.LicensePlate).Length(50).Unique().Not.Nullable();
            Map(x => x.Brand).Length(50).Not.Nullable();
            Map(x => x.Model).Length(50).Not.Nullable();
            Map(x => x.Insurance).Not.Nullable();
            Map(x => x.LeasingFrom).Not.Nullable();
            Map(x => x.LeasingTo).Not.Nullable();
            Map(x => x.LeasingRate).Not.Nullable();
            Map(x => x.Version).Not.Nullable();
        }
    }
}