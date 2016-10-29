using FluentNHibernate.Cfg;
using NHibernate;

namespace Database
{
    public static class Session
    {
        private static ISessionProvider provider = CreateSessionProvider();

        private static ISessionProvider CreateSessionProvider()
        {
            if (InMemorySessionProvider.useMe) return new InMemorySessionProvider();
            else return new DBSessionProvider();
        }

        public static ISession GetDatabaseSession()
        {
            return provider.GetSession();
        }
    }

    public interface ISessionProvider
    {
        ISession GetSession();
    }
}