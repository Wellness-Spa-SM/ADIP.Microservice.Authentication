using System.Diagnostics;
using System.Security.Cryptography;

namespace Authentication.UnitTest
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
            using var random = RandomNumberGenerator.Create();
            Debug.WriteLine(random.ToString());
            Assert.Pass();
        }
    }
}
