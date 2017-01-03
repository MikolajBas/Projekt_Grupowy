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
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var property = session.Query<DataPropertiesConfiguration>().First(x => x.Id == config.PropertyId);

                transaction.Commit();

                return string.Format("{0}({1} {2} {3}) {4} {5}",
                    config.Function, property.Name, config.PropertyOperator, config.PropertyValue, config.Operator, config.ResultValue);
            }
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
    }
}
