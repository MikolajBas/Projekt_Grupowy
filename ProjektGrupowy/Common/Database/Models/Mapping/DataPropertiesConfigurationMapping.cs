using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class DataPropertiesConfigurationMapping : ClassMap<DataPropertiesConfiguration>
    {
        DataPropertiesConfigurationMapping()
        {
            Table("data_property_configurations");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Name).Not.Nullable().Column("name");
            Map(x => x.TypeId).Not.Nullable().Column("type_id");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
        }
    }
}
