using FluentNHibernate.Mapping;

namespace Database.Models.Mapping
{
    class DataMapping : ClassMap<Data>
    {
        DataMapping()
        {
            Table("sites_data");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Ip).Not.Nullable().Column("ip");
            Map(x => x.ProductId).Column("product_id");
            Map(x => x.ProductName).Column("product_name");
            Map(x => x.ScreenResolution).Column("screen_resolution");
            Map(x => x.Agent).Column("agent");
            Map(x => x.Browser).Column("browser");
            Map(x => x.CategoryId).Not.Nullable().Column("category_id");
            Map(x => x.System).Column("system");
            Map(x => x.Url).Not.Nullable().Column("url");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
            Map(x => x.Date).Column("visit_date");
        }
    }
}
