
using remont;
using NUnit;
using System.Collections.Generic;
namespace TestProject1;
public class Tests
    {
    [TestFixture]
    public class FinctionalTests
    {
        [Test]
        public void asdasdasasdasdasd()
        {
            var finctional = new Finctional();
            var result = finctional.CountApp();
            Assert.That(Equals("1", result));
        }
    }


}
