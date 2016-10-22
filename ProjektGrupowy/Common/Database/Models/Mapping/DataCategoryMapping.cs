using FluentNHibernate.Mapping;


namespace Database.Models.Mapping
{
    class DataCategoryMapping : ClassMap<DataCategory>
    {
        DataCategoryMapping()
        {
            Table("data_categories");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Name).Not.Nullable().Column("name");
            Map(x => x.CategoryId).Not.Nullable().Column("category_id");
            Map(x => x.UserId).Not.Nullable().Column("user_id");
        }
    }
}
