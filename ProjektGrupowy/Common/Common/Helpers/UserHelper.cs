using Database;
using Database.Models;
using Data.Enums;
using NHibernate.Linq;
using System.Linq;

namespace Common.Helpers
{
    public static class UserHelper
    {
        public static bool ValidateUser(string login, string password, AccountType accountType)
        {
            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var user = session.Query<User>().FirstOrDefault(x => x.Login == login && x.Password == password && x.AccountType == accountType);

                transaction.Commit();

                if (user == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
