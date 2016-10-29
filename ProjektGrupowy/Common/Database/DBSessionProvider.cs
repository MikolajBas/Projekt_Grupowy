using FluentNHibernate.Cfg;
using NHibernate;

namespace Database
{
    class DBSessionProvider : ISessionProvider
    {
        private ISessionFactory _sessionFactory;

        public DBSessionProvider()
        {
            _sessionFactory = CreateSessionFactory();

        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(OdbcConfiguration.PgDb()
                .Driver<NHibernate.Driver.OdbcDriver>()
                .Dialect<NHibernate.Dialect.MySQLDialect>())
                .Mappings(x => x.UsePersistenceModel(new HibernateModel()))
                .ExposeConfiguration(c => c.SetProperty("connection.release_mode", "on_close"))
                .BuildSessionFactory();
        }

        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }

    }
}