using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

namespace Dao
{
    public class ProductDao : IProductDao
    {
        private ISessionFactory sessionFactory;

        public ProductDao()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure(NHibernateCfgPicker.GetCfgFilePath());
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(Domain.Product entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(Domain.Product entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(Domain.Product entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public Domain.Product Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<Domain.Product>(id);
            }
        }

        public Domain.Product Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<Domain.Product>(id);
            }
        }

        public IList<Domain.Product> LoadAll()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<Domain.Product>().ToList();
            }
        }
    }
}
