using NHibernate;

namespace Database.Models
{
    public class BaseModel<T>
    {
        #region Insert
        public virtual void Insert(T model)
        {
            using (var session = Connector.OpenSession())
            {
                Insert(session, model);
            }
        }
        
        public virtual void Insert(ISession session, T model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
            }
        }
        #endregion

        #region Update
        public virtual void Update(T model)
        {
            using (var session = Connector.OpenSession())
            {
                Update(session, model);
            }
        }

        public virtual void Update(ISession session, T model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(model);
                transaction.Commit();
            }
        }
        #endregion

        #region Delete
        public virtual void Delete(T model)
        {
            using (var session = Connector.OpenSession())
            {
                Delete(session, model);
            }
        }

        public virtual void Delete(ISession session, T model)
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
