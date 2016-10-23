using Common.Helpers;
using Common.Serializers;
using Configurator;
using Database;
using Database.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace CollectorService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CollectorService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void Collect(string jsonData, string userGuid)
        {
            var serializer = new DataSerializer();
            var data = serializer.Deserialize<Data>(jsonData);
            
            return;
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

                    }
                }

                transaction.Commit();
                return string.Empty;
            }
        }
    }
}
