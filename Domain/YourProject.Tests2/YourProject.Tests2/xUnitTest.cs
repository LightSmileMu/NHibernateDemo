//using Xunit;
//using Xunit.Extensions;

using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace YourProject.Tests2
{
    public class XUnitTest
    {
        public static IEnumerable<object[]> InputDataProperty
        {
            get
            {
                var driverData = new List<object[]>
                {
                    new object[] {1, 1, 2},
                    new object[] {1, 1, 2},
                    new object[] {1, 2, 3},
                    new object[] {1, 4, 2},
                    new object[] {1, 3, 2},
                    new object[] {1, 6, 7}
                };
                return driverData;
            }
        }

        [Fact(DisplayName = "Lesson02.Demo01")]
        public void Demo01_Fact_Test()
        {
            const int num01 = 1;
            const int num02 = 2;
            Assert.Equal(3, num01 + num02);
        }

        [Theory(DisplayName = "Lesson02.Demo3")]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 6)]
        public void Demo03_Theory_Test(int num01, int num02, int result)
        {
            Assert.Equal(result, num01 + num02);
            //Assert.ThrowsDelegate del = GetFile;

            //Assert.Throws(typeof(FileNotFoundException), del);
        }
    }

    internal interface IInterface
    {
        void MyFunc();
    }
}