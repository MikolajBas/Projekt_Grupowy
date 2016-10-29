using System;
using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;

namespace Database
{
    public class InMemorySessionProvider : ISessionProvider
    {
        private static ISessionFactory _sessionFactory = null;
        internal static bool useMe = false;

        public static void UseMe()
        {
            useMe = true;
        }

        static IDbConnection _connection;
        /// <summary>
        /// Recreates empty DB in memory which is visible between sessions
        /// </summary>
        public static void StartNewDBSession()
        {
            if (useMe == false) throw new InvalidOperationException("UseMe not set");
            CreateSessionFactory();
            if (_connection != null) _connection.Close();
            _connection = ((ISessionFactoryImplementor)_sessionFactory).ConnectionProvider.GetConnection();
            using (var session = Connector.OpenSession())
            {
                BuildSchema(session);
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            if (_sessionFactory == null)
                _sessionFactory =
                    Fluently
                        .Configure()
                        .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                        .Mappings(x => x.UsePersistenceModel(new HibernateModel()))
                        .ExposeConfiguration((c) => SavedConfig = c)
                        .BuildSessionFactory();
            return _sessionFactory;
        }

        private static Configuration SavedConfig;

        public ISession GetSession()
        {
            var session = _sessionFactory.OpenSession(_connection);
            return session;
        }

        public static void BuildSchema(ISession session)
        {
            var export = new SchemaExport(SavedConfig);
            export.Execute(true, true, false, session.Connection, null);
        }
    }
}