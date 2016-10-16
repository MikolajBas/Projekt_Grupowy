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
        public static Logger _logger = new Logger("Common.Helpers.UserHelper");

        public static bool ValidateUser(ISession session, string login, string password, AccountType accountType)
        {
            var user = session.Query<User>().FirstOrDefault(x => x.Login == login && x.Password == password && x.AccountType == accountType);
            
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public static string CreateUser(User user)
        {
            try
            {
                user.Password = TextHelper.Hash(user.Password);

                using (var session = Connector.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    if (ValidateUser(session, user.Login, user.Password, user.AccountType))
                    {
                        session.Save(user);
                    }
                    else
                    {
                        transaction.Commit();
                        return "User already exists in system";
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return "Error during user creation";
            }

            return "User created successfully";
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
    }
}
