using Data.Enums;
using FluentNHibernate.Mapping;

namespace Database.Models.Mapping
{
    class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("users");
            Id(x => x.Id).Not.Nullable().Column("id");
            Map(x => x.UserName).Not.Nullable().Column("login");
            Map(x => x.Password).Not.Nullable().Column("password");
            Map(x => x.Email).Not.Nullable().Column("email");
            Map(x => x.Name).Not.Nullable().Column("name");
            Map(x => x.Surname).Not.Nullable().Column("surname");
            Map(x => x.Url).Not.Nullable().Column("url");
            Map(x => x.Guid).Not.Nullable().Column("guid");
            Map(x => x.AccountType).Not.Nullable().CustomType<AccountType>().Column("account_type");
        }
    }
}
