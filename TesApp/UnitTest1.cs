using remont;
namespace TesApp
{
    public class Tests
    {
        [TestFixture]
        public class FinctionalTests
        {
            [Test]
            public void Test1()
            {
                var finctional = new Finctional();
                var result = finctional.CountApp();
                Assert.That(Equals("1", result));
            }
        }

       
    }
}