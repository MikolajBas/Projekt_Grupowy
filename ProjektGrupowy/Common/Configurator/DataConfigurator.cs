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

        public bool IsConfigurationValid(int userId, string name, string value)
        {
            var config = new DataPropertiesConfiguration();

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                config = session.Query<DataPropertiesConfiguration>().FirstOrDefault(x => x.UserId == userId && x.Name == name);
                transaction.Commit();
            }

            if (config == null)
            {
                return false;
            }

            return TryParsePropertyType(config.TypeId, value);
        }

        public bool TryParsePropertyType(int typeId, string value)
        {
            var type = (PropertyType)typeId;

            switch (type)
            {
                case PropertyType.DateTime:
                    DateTime time = new DateTime();
                    return DateTime.TryParse(value, out time);

                case PropertyType.Int:
                    int i = 0;
                    return int.TryParse(value, out i);

                case PropertyType.String:
                    return true;

                default:
                    return false;
            }
        }
    }
}
