using FluentNHibernate;

namespace Database
{
    internal class HibernateModel : PersistenceModel
    {
        public HibernateModel()
        {
            AddMappingsFromThisAssembly();
        }
    }
}