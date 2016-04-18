using NHibernate;
using NHibernate.Cfg;
using NHibernateTest.Utility;
using NUnit.Framework;

namespace NHibernateTest
{
    [TestFixture]
    public class NHibernateInit
    {
        [Test]
        public void InitTest()
        {

            Configuration cfg = new Configuration().Configure(NHibernateCfgPicker.GetCfgFilePath());
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
            }
        }
    }
}