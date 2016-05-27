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
                if (_factory == null)
                {
                    lock (FactoryLock)
                    {
                        if (_factory == null)
                        {
                            var cfg = new Configuration().Configure(NHibernateCfgPicker.GetCfgFilePath());
                            _factory = cfg.BuildSessionFactory();
                        }
                    }
                }
                return _factory;
            }
        }
    }
}