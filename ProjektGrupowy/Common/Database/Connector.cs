using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Database.Models;

namespace Database
{
    public class Connector
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(x => x.Server("localhost")
                                            .Database("pgdb")
                                            .Username("root")
                                            .Password("inz15/16"))
                    .ShowSql() //FromConnectionStringWithKey("Server=localhost; Port=3306; Database=dotnot; Uid=root; Pwd=inz15/16;")
                )
                .Mappings(m =>
                          m.FluentMappings
                            .AddFromAssemblyOf<Connector>())
                            .ExposeConfiguration(cfg => new SchemaExport(cfg)
                            .Create(false, false)
                          )
                          .BuildConfiguration()
                          .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public IUserStore<User, int> Users
        {
            get { return new IdentityStore(OpenSession()); }
        }
    }
}
