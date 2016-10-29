using FluentNHibernate.Cfg.Db;

namespace Database
{
    internal class OdbcConfiguration : PersistenceConfiguration<OdbcConfiguration, FluentNHibernate.Cfg.Db.OdbcConnectionStringBuilder>
    {
        protected OdbcConfiguration()
        {
            Driver<NHibernate.Driver.OdbcDriver>();
        }

        public static OdbcConfiguration PgDb()
        {
            return new OdbcConfiguration().ConnectionString("DSN=pgdb");
        }
    }
}