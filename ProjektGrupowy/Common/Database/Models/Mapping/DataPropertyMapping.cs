using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class DataPropertyMapping : ClassMap<DataProperty>
    {
        DataPropertyMapping()
        {
            Table("data_properties");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.PropertyId).Not.Nullable().Column("property_id");
            Map(x => x.Value).Not.Nullable().Column("property_value");
            Map(x => x.DataId).Not.Nullable().Column("data_id");
        }
    }
}
