using NHibernate;

namespace Database.Models
{
    public class BaseModel<T>
    {
        #region Insert
        public void Insert(T model)
        {
            using (var session = Connector.OpenSession())
            {
                Insert(session, model);
            }
        }
        
        public void Insert(ISession session, T model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
            }
        }
        #endregion

        #region Update
        public void Update(T model)
        {
            using (var session = Connector.OpenSession())
            {
                Update(session, model);
            }
        }

        public void Update(ISession session, T model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(model);
                transaction.Commit();
            }
        }
        #endregion

        #region Delete
        public void Delete(T model)
        {
            using (var session = Connector.OpenSession())
            {
                Delete(session, model);
            }
        }

        public void Delete(ISession session, T model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(model);
                transaction.Commit();
            }
        }
        #endregion
    }
}
