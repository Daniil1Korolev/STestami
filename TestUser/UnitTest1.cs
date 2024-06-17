using remont;


namespace TestUser
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
            var functional = new Functional();
            var result = functional.CountApplication();
            Assert.AreEqual("2", result);
        }
    }
}