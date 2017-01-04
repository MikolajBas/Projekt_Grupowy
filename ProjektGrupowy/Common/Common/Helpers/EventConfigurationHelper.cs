using Database;
using Database.Models;
using NHibernate.Linq;
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
