using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class EventConfigurationPropertyMapping : ClassMap<EventConfigurationProperty>
    {
        EventConfigurationPropertyMapping()
        {
            Table("event_configuration_properties");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.PropertyId).Not.Nullable().Column("property_id");
            Map(x => x.EventConfigurationId).Not.Nullable().Column("event_configuration_id");
            Map(x => x.Position).Not.Nullable().Column("position");
        }
    }
}
