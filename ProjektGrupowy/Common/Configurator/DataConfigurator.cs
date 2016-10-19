using Common.Helpers;
using Data.Enums;
using Database;
using Database.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Configurator
{
    public class DataConfigurator
    {
        public DataConfigurator()
        {
        }

        public void AddDataPropertiesConfiguration(string name, string type, int userId)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var config = session.Query<DataPropertiesConfiguration>()
                                .FirstOrDefault(x => x.Name == name && x.UserId == userId);

                if (config != null)
                {
                    throw new Exception("Data property is already exists");
                }

                config = new DataPropertiesConfiguration
                {
                    Name = name,
                    TypeId = (int)EnumHelper.ParseEnum<PropertyType>(type),
                    UserId = userId
                };

                session.Save(config);
                transaction.Commit();
            }
        }

        public List<DataPropertiesConfiguration> GetUserConfigurations(int userId)
        {
            var configurations = new List<DataPropertiesConfiguration>();

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                configurations = session.Query<DataPropertiesConfiguration>().Where(x => x.UserId == userId).ToList();
                transaction.Commit();
            }

            if (!configurations.Any())
                throw new Exception("No configurations found");

            return configurations;
        }

        public void AddDataCategory(string name, int categoryId, int userId)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var config = session.Query<DataCategory>()
                                .FirstOrDefault(x => x.Name == name && x.UserId == userId);

                if (config != null)
                {
                    throw new Exception("Data property is already exists");
                }

                config = new DataCategory
                {
                    Name = name,
                    CategoryId = categoryId,
                    UserId = userId
                };

                session.Save(config);
                transaction.Commit();
            }
        }

        public List<DataCategory> GetUserCategories(int userId)
        {
            var categories = new List<DataCategory>();

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                categories = session.Query<DataCategory>().Where(x => x.UserId == userId).ToList();
                transaction.Commit();
            }

            if (!categories.Any())
                throw new Exception("No categories found");

            return categories;
        }
    }
}
