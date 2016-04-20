using NHibernate;
using NHibernate.Cfg;

namespace NHibernateTest.Utility
{
    internal class SessionFactory
    {
        private static ISessionFactory _factory;

        private static readonly object FactoryLock = new object();

        public static ISessionFactory Factory
        {
            get
            {
                if (_factory != null) return _factory;
                lock (FactoryLock)
                {
                    if (_factory != null) return _factory;
                    var cfg = new Configuration().Configure(NHibernateCfgPicker.GetCfgFilePath());
                    return _factory = cfg.BuildSessionFactory();
                }
            }
        }
    }
}