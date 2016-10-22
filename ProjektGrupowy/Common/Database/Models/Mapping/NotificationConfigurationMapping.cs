using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class NotificationConfigurationMapping : ClassMap<NotificationConfiguration>
    {
        NotificationConfigurationMapping()
        {
            Table("notification_configurations");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.OperatorId).Not.Nullable().Column("operator_id");
            Map(x => x.Period).Not.Nullable().Column("period");
            Map(x => x.PropertyId).Not.Nullable().Column("property_id");
            Map(x => x.PropertyValue).Not.Nullable().Column("property_value");
            Map(x => x.ResultValue).Not.Nullable().Column("result_value");
            Map(x => x.Message).Column("message");
            Map(x => x.PropertyOperatorId).Not.Nullable().Column("property_operator_id");
            Map(x => x.FunctionId).Column("function_id");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
        }
    }
}
