using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Database;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Common.Helpers
{
    public class SiteCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public static class StatisticsHelper
    {
        public static List<SiteCount> GetSitesStatistics(string parameterName, int userId, DateTime startDate, DateTime endDate)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var records = session.CreateCriteria<Database.Models.Data>()
                    .SetProjection(Projections.ProjectionList()
                        .Add(Projections.Alias(Projections.GroupProperty(parameterName), "Name"))
                        .Add(Projections.Alias(Projections.Count(Projections.Id()), "Count")))
                    .SetResultTransformer(Transformers.AliasToBean(typeof(SiteCount)))
                    .Add(Expression.Between("Date", startDate, endDate))
                    .Add(Expression.Eq("UserId", userId))
                    .List<SiteCount>();

                transaction.Commit();

                return records.ToList();
            }
        }
    }
}
