using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class EventConfigurationMapping : ClassMap<EventConfiguration>
    {
        EventConfigurationMapping()
        {
            Table("event_configurations");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Operator).Not.Nullable().Column("event_operator");
            Map(x => x.Period).Not.Nullable().Column("period");
            Map(x => x.PropertyId).Not.Nullable().Column("property_id");
            Map(x => x.PropertyValue).Not.Nullable().Column("property_value");
            Map(x => x.ResultValue).Not.Nullable().Column("result_value");
            Map(x => x.Function).Column("event_function");
            Map(x => x.Category).Not.Nullable().Column("category");
            Map(x => x.Template).Column("template");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
        }

    }
}
