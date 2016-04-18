using System;
using Domain;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using NHibernateTest.Utility;
using NUnit.Framework;

namespace NHibernateTest
{
    [TestFixture]
    public class LifecycleTest
    {
        [SetUp]
        public void Init()
        {
            Configuration cfg = new Configuration().Configure(NHibernateCfgPicker.GetCfgFilePath());
            _sessionFactory = cfg.BuildSessionFactory();
        }

        private ISessionFactory _sessionFactory;

        public LifecycleTest()
        {
            XmlConfigurator.Configure();
        }

        [Test]
        public void DeleteTest()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var product = new Product
                    {
                        ID = Guid.NewGuid(),
                        BuyPrice = 23M,
                        Code = "asdfads",
                        Name = "计算器",
                        QuantityPerUnit = "78",
                        SellPrice = 32M,
                        Unit = "台"
                    };

                    try
                    {
                        session.Save(product);

                        session.Delete(product);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        [Test]
        public void GetNullTest()
        {
            Guid id = Guid.NewGuid();
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var product = session.Get<Product>(id);
                        Console.WriteLine("调用Get()方法");

                        Assert.Null(product);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        [Test]
        public void LoadTest()
        {
            Guid id = Guid.NewGuid();
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var product = session.Load<Product>(id);
                        Console.WriteLine("调用Load()方法");

                        Assert.NotNull(product.Name);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        [Test]
        public void PersistentToTestDetached()
        {
            var product = new Product
            {
                ID = Guid.NewGuid(),
                BuyPrice = 10M,
                Code = "454645646",
                Name = "电脑",
                QuantityPerUnit = "20x1",
                SellPrice = 13M,
                Unit = "台"
            };

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(product);
                        product.SellPrice = 23M;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }


            product.SellPrice = 56M;

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(product);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        [Test]
        public void TransientToPersistentTest()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var product = new Product
                    {
                        ID = Guid.NewGuid(),
                        BuyPrice = 11M,
                        Code = "12154",
                        Name = "pc",
                        QuantityPerUnit = "45",
                        SellPrice = 22M,
                        Unit = "台"
                    };

                    try
                    {
                        session.Save(product);
                        product.SellPrice = 12M;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        [Test]
        public void UpdateTest()
        {
            Guid id = Guid.NewGuid();

            #region Save data

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var product = new Product
                    {
                        ID = id,
                        BuyPrice = 23M,
                        Code = "02xa",
                        Name = "sajfk",
                        QuantityPerUnit = "dfa",
                        Remark = "sdfa",
                        SellPrice = 45M,
                        Unit = "台"
                    };

                    try
                    {
                        session.Save(product);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }

            #endregion

            #region Update data

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var product1 = new Product
                    {
                        ID = id,
                        SellPrice = 78M
                    };


                    try
                    {
                        session.Update(product1);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }

            #endregion
        }
    }
}