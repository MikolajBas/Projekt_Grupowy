using Database;
using Database.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool CheckEvent(int configId, string ip)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var config = session.Query<EventConfiguration>().FirstOrDefault(x => x.Id == configId);

                if (config == null)
                {
                    transaction.Commit();
                    return false;
                }

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

                var value = query.List<int>().First();

                transaction.Commit();

                return IsResultCorrect(value, config.ResultValue, config.Operator) ? true : false;
            }
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
/*
select 
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