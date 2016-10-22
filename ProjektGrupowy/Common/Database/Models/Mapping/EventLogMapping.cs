using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class EventLogMapping : ClassMap<EventLog>
    {
        EventLogMapping()
        {
            Table("event_logs");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Ip).Not.Nullable().Column("ip");
            Map(x => x.EventConfigurationId).Not.Nullable().Column("event_configuration_id");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
            Map(x => x.Date).Not.Nullable().Column("event_date");
        }
    }
}
