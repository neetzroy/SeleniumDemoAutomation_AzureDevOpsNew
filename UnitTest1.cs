using NUnit.Framework;

namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void CloseBrowser()
        {

        }
    }
}