using System;
using System.Linq;
using Dao;
using Domain;
using NUnit.Framework;

namespace NHibernateTest
{
    [TestFixture]
    public class ProductDaoTest
    {
        [SetUp]
        public void Init()
        {
            _productDao = new ProductDao();
        }

        private IProductDao _productDao;

        [Test]
        public void DeleteTest()
        {
            Product product = _productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            Guid id = product.ID;
            _productDao.Delete(product);
            Assert.Null(_productDao.Get(id));
        }

        [Test]
        public void GetTest()
        {
            Product product = _productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            Guid id = product.ID;
            Assert.NotNull(_productDao.Get(id));
        }

        [Test]
        public void LoadAllTest()
        {
            int count = _productDao.LoadAll().Count;
            Assert.True(count > 0);
        }

        [Test]
        public void LoadTest()
        {
            Product product = _productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            Guid id = product.ID;
            Assert.NotNull(_productDao.Get(id));
        }

        [Test]
        public void SaveTest()
        {
            var product = new Product
            {
                ID = Guid.NewGuid(),
                BuyPrice = 10M,
                Code = "ABC123",
                Name = "电脑",
                QuantityPerUnit = "20x1",
                SellPrice = 11M,
                Unit = "台"
            };

            object obj = _productDao.Save(product);

            Assert.NotNull(obj);
        }

        [Test]
        public void UpdateTest()
        {
            Product product = _productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            product.SellPrice = 28M;

            _productDao.Update(product);


            Assert.AreEqual(28M, product.SellPrice);
        }
    }
}