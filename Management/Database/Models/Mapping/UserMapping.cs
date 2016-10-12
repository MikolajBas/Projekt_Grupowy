using FluentNHibernate.Mapping;

namespace Database.Models.Mapping
{
    class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("user");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.Login).Not.Nullable().Column("login");
            Map(x => x.Password).Not.Nullable().Column("password");
            Map(x => x.Email).Not.Nullable().Column("email");
            Map(x => x.Name).Not.Nullable().Column("name");
            Map(x => x.Surname).Not.Nullable().Column("surname");
            Map(x => x.AccountType).Not.Nullable().Column("account_type");
        }
    }
}
