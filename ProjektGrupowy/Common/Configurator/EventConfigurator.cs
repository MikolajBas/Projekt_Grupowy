using Data.Enums;
using Database;
using Database.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Configurator
{
    public class EventConfigurator
    {
        public EventConfigurator()
        {
        }

        public void AddConfiguration()
        {
        }

        public bool CheckEvent(EventConfiguration config, string ip)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {   
                var value = GetEventConditionResult(session, config, ip);

                transaction.Commit();

                return IsResultCorrect(value, config.ResultValue, config.Operator) ? true : false;
            }
        }

        public int GetEventConditionResult(ISession session, EventConfiguration config, string ip)
        {
            var query = session.CreateSQLQuery(string.Format(
                    @"select 
                        {0}(dp.value)
                    from
                        pgdb.data as d
                    inner join
                        pgdb.data_property as dp
                    on
                        d.id = dp.data_id
                    where
                        d.user_id = {1} and
                        d.ip = {2} and
                        d.category_id = {3} and
                        dp.property_id = {4} and
                        dp.value {5} {6};",
                        config.Function, config.UserId, ip, config.CategoryId, config.PropertyId, config.PropertyOperator, config.PropertyValue))
                        .AddEntity(typeof(int));

            return query.List<int>().First();
        }

        public Database.Models.Data GetSmartResult(EventConfiguration config, string ip)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var property = session.Query<DataPropertiesConfiguration>().First(x => x.Id == config.PropertyId);
                IList<int> query;

                if ((PropertyType)property.TypeId == PropertyType.Int || (PropertyType)property.TypeId == PropertyType.DateTime)
                {
                    config.Function = "max";
                    var max = GetEventConditionResult(session, config, ip);

                    config.Function = "min";
                    var min = GetEventConditionResult(session, config, ip);

                    query = session.CreateSQLQuery(string.Format(
                        @"select 
                            d.id
                        from
                            pgdb.data as d
                        inner join
                            pgdb.data_property as dp
                        on
                            d.id = dp.data_id
                        where
                            d.category_id = {0} and
                            dp.property_id = {1} and
                            dp.value between {2} and {3};",
                    config.CategoryId, config.PropertyId, min, max))
                    .AddEntity(typeof(int)).List<int>();
                }
                else
                {
                    query = session.CreateSQLQuery(string.Format(
                        @"select 
                            d.id
                        from
                            pgdb.data as d
                        inner join
                            pgdb.data_property as dp
                        on
                            d.id = dp.data_id
                        where
                            d.category_id = {0} and
                            dp.property_id = {1} and
                            dp.value = {2}",
                    config.CategoryId, config.PropertyId, config.PropertyValue))
                    .AddEntity(typeof(int)).List<int>();
                }

                var random = new Random();
                var index = random.Next(query.Count);
                var id = query[index];
                
                transaction.Commit();

                return session.Query<Database.Models.Data>().First(x => x.Id == id);
            }
        }

        public string ParseTemplate(EventConfiguration config, Database.Models.Data data)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var configProperties = session.Query<EventConfigurationProperty>().Where(x => x.EventConfigurationId == config.Id);
                
                foreach (var configProperty in configProperties)
                {
                    var property = session.Query<DataProperty>().First(x => x.PropertyId == configProperty.PropertyId);

                    config.Template.Replace(string.Format("{{0}}", configProperty.Position), property.Value);
                }
            }

            return config.Template;
        }

        public bool IsResultCorrect(int value, int resultValue, string @operator)
        {
            switch (@operator)
            {
                case "=":
                    return value == resultValue;
                case ">":
                    return value > resultValue;
                case "<":
                    return value < resultValue;
                default:
                    return false;
            }
        }
    }
}


//example sql
/*select 
    sum(dp.value)
from
    pgdb.data as d
inner join
    pgdb.data_property as dp
on
    d.id = dp.data_id
where
    d.user_id = 1 and
    d.ip = '127.0.0.1' and
    d.category_id = 1 and
    dp.property_id = 1 and
    dp.value > 10;

*/