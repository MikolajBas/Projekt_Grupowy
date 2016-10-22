using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class NotificationMapping : ClassMap<Notification>
    {
        NotificationMapping()
        {
            Table("notifications");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Message).Not.Nullable().Column("message");
            Map(x => x.NotificationConfigurationId).Not.Nullable().Column("notification_configuration_id");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
            Map(x => x.Date).Not.Nullable().Column("notification_date");
        }
    }
}
