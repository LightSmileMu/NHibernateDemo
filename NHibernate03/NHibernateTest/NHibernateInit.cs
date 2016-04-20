using System;
using System.Linq;
using Domain;
using NHibernate;
using NHibernateTest.Utility;
using NUnit.Framework;

namespace NHibernateTest
{
    [TestFixture]
    public class NHibernateInit
    {
        private ISessionFactory _sessionFactory;

        [SetUp]
        public void InitTest()
        {
            _sessionFactory = SessionFactory.Factory;
        }

        [TearDown]
        public void DisposeFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Dispose();
            }
        }

        [Test]
        public void Save()
        {

            if (_sessionFactory == null) return;
            
            using (ISession session = _sessionFactory.OpenSession())
            {
                var cls = new Class { Name = "1班" };
                var liu = new Student { Name = "刘冬", Class = cls };
                var zhang = new Student { Name = "张三", Class = cls };

                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(cls);
                        session.Save(liu);
                        session.Save(zhang);
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
        public void Select()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                var student = session.CreateQuery(" from Student").List<Student>().First();

                Console.WriteLine("学生名为：{0}", student.Name);
                Console.WriteLine("班级名为：{0}", student.Class.Name);
            }
        }

        [Test]
        public void SaveFamily()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                var student = new Student {Name = "刘冬"};
                var family = new Family {Address = "新疆乌鲁木齐市", Student = student};

                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(family);
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
        public void SelectFamily()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {

                try
                {
                    var family = session.CreateQuery(" From Family").List<Family>().First();
                    Assert.NotNull(family);
                    Console.WriteLine("家庭地址：{0}", family.Address);
                    Console.WriteLine("学生姓名：{0}", family.Student.Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [Test]
        public void SelectStudentTest()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {

                try
                {
                    var student = session.Get<Student>(1);
                    Assert.NotNull(student);
                    Console.WriteLine("家庭地址：{0}", student.Family.Address);
                    Console.WriteLine("学生姓名：{0}", student.Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [Test]
        public void SaveTeacherTest()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var teacher = new Teacher {Name = "刘冬"};
                    var class1 = new Class {Teacher = teacher, Name = "2班"};
                    teacher.Class = class1;
                    try
                    {
                        session.Save(teacher);
                        session.Save(class1);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

       
    }
}