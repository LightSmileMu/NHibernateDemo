using System.Data;
using NUnit.Framework;

namespace NHibernateTest
{
    class MysqlHelperTest
    {

        [Test]
        [TestCase("t_class")]
        [TestCase("t_student")]
        [TestCase("t_family")]
        public void GetAllTest(string tableName)
        {
           var table = MySqlHelper.GetAll(tableName);
           Assert.True(table.Columns.Count > 0); 
        }
    }
}
