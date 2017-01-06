using Data.Enums;
using Database;
using Database.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class EventConfigurationHelper
    {
        public static string FormatEventToString(EventConfiguration config)
        {
            var propertyName = DataConfigurationHelper.GetPropertyName(config.PropertyId);

            return string.Format("{0}({1} {2} {3}) {4} {5}",
                config.Function, propertyName, config.PropertyOperator, config.PropertyValue, config.Operator, config.ResultValue);
        }
    
        public static List<EventConfiguration> GetUserEventConfigurations(long userId)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var configs = session.Query<EventConfiguration>().Where(x => x.UserId == userId).ToList();

                transaction.Commit();
                return configs;
            }
        }

        public static string ConvertTemplatePropertiesFromIdsToNames(string propertyIds)
        {
            if (string.IsNullOrEmpty(propertyIds))
                return string.Empty;

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var ids = propertyIds.Split(',');
                var result = new List<string>();

                foreach (var id in ids)
                {
                    var property = session.Query<DataPropertiesConfiguration>().FirstOrDefault(x => x.Id == Convert.ToInt32(id));
                    var nameValue = string.Empty;

                    if (property != null)
                    {
                        nameValue = property.Name.ToString();
                    }
                    else
                    {
                        try
                        {
                            nameValue = ((BasicDataProperty)Convert.ToInt32(id)).ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    result.Add(nameValue ?? string.Empty);
                }

                transaction.Commit();

                return string.Join(",", result.ToArray());
            }
        }

        public static string ConvertTemplatePropertiesFromNamesToIds(string propertyNames)
        {
            if (string.IsNullOrEmpty(propertyNames))
                return string.Empty;

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var names = propertyNames.Split(',');
                var result = new List<string>();

                foreach (var name in names)
                {
                    var property = session.Query<DataPropertiesConfiguration>().FirstOrDefault(x => x.Name == name);
                    var idValue = string.Empty;

                    if (property != null)
                    {
                        idValue = property.Id.ToString();
                    }
                    else
                    {
                        try
                        {
                            idValue = ((int)EnumHelper.ParseEnum<BasicDataProperty>(name)).ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    result.Add(idValue ?? string.Empty);
                }

                transaction.Commit();

                return string.Join(",", result.ToArray());
            }
        }

        public static EventConfiguration GetConfiguration(long configId)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var config = session.Query<EventConfiguration>().First(x => x.Id == configId);
                
                transaction.Commit();
                return config;
            }
        }

        public static void AddConfiguration(EventConfiguration config)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(config);
                transaction.Commit();
            }
        }

        public static void UpdateConfiguration(EventConfiguration config)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(config);
                transaction.Commit();
            }
        }

        public static void DeleteConfiguration(EventConfiguration config)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(config);
                transaction.Commit();
            }
        }
    }
}
