using Database;
using Database.Models;
using Data.Enums;
using NHibernate.Linq;
using System.Linq;
using Common.Logging;
using System;
using NHibernate;

namespace Common.Helpers
{
    public static class UserHelper
    {
        public static Logger _logger = new Logger("Common.Managers.UserHelper");
        
        public static bool ValidateUser(ISession session, string login, string password, AccountType accountType)
        {
            var user = session.Query<User>().FirstOrDefault(x => x.UserName == login && x.Password == password && x.AccountType == accountType);
            
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public static string UpdateUser(User user)
        {
            try
            {
                using (var session = Connector.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return "User update failed";
            }

            return "User updated successfully";
        }

        public static string DeleteUser(int id)
        {
            try
            {
                using (var session = Connector.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var user = session.Query<User>().FirstOrDefault(x => x.Id == id);

                    if (user != null)
                    {
                        session.Delete(user);
                    }
                    else
                    {
                        transaction.Commit();
                        return "User to delete was not found";
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return "User delete failed";
            }

            return "User deleted successfully";
        }

        public static User GetUser(int id)
        {
            try
            {
                using (var session = Connector.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var user = session.Query<User>().FirstOrDefault(x => x.Id == id);

                    transaction.Commit();

                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        throw new Exception(string.Format("No user found with id: {0}", id));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                throw ex;
            }
        }

        public static User GetUserByGuid(ISession session, string guid)
        {
            try
            {
                var user = session.Query<User>().FirstOrDefault(x => x.Guid == guid);
                
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception(string.Format("No user found with guid: {0}", guid));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                throw ex;
            }
        }

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
