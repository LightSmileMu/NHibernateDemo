using Xunit;


namespace YourProject.Tests1
{
    public class xUnitTest
    {
        public xUnitTest()
        {

        }

        [Fact]
        public void Test()
        {
            Assert.Equal(5,6);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(5, 5);
        }
    }
}
