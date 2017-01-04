using Data.Data;
using Database;
using Database.Models;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class DataConfigurationHelper
    {
        public static List<UserDataProperty> GetUserDataProperties(long userId)
        {
            var properties = new List<UserDataProperty>();

            properties.AddRange(GetBasicDataProperties());
            properties.AddRange(GetCustomDataProperties(userId));

            return properties;
        }

        public static List<UserDataProperty> GetCustomDataProperties(long userId)
        {
            var properties = new List<UserDataProperty>();

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var customProperties = session.Query<DataPropertiesConfiguration>().Where(x => x.UserId == userId);

                foreach (var customProperty in customProperties)
                {
                    properties.Add(new UserDataProperty
                    {
                        Id = customProperty.Id,
                        Name = customProperty.Name,
                        IsBasic = false
                    });
                }

                transaction.Commit();
            }
            return properties;
        }

        public static List<UserDataProperty> GetBasicDataProperties()
        {
            return new List<UserDataProperty>
            {
                new UserDataProperty
                {
                    Id = 0,
                    Name = "ip",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "product_id",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "product_name",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "screen_resolution",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "agent",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "browser",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "screen_resolution",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "category",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "system",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "url",
                    IsBasic = true
                },
                new UserDataProperty
                {
                    Id = 0,
                    Name = "visit_date",
                    IsBasic = true
                },

            };
        }
    }
}
