using Common.Helpers;
using Common.Managers;
using Common.Serializers;
using Configurator;
using Database;
using Database.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace CollectorService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CollectorService
    {
        [OperationContract]
        public void Collect(string jsonData, string jsonDataProperties, string userGuid)
        {
            var serializer = new DataSerializer();
            var data = serializer.Deserialize<Data>(jsonData);
            var dataProperties = serializer.Deserialize<List<DataProperty>>(jsonDataProperties);

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(data);

                foreach (var dataProperty in dataProperties)
                {
                    session.Update(dataProperty);
                }

                transaction.Commit();
            }
        }

        [OperationContract]
        public string GetResponse(string userGuid, string ip)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var configurator = new EventConfigurator();
                
                var userId = UserHelper.GetUserByGuid(session, userGuid).Id;
                
                var configs = session.Query<EventConfiguration>().Where(x => x.UserId == userId);

                foreach (var config in configs)
                {
                    if (configurator.CheckEvent(session, config, ip))
                    {
                        var data = configurator.GetSmartResult(session, config, ip);

                        return configurator.ParseTemplate(session, config, data);
                    }
                }

                transaction.Commit();
                return string.Empty;
            }
        }
    }
}
