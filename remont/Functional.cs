using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace remont
{ 
[TestFixture]

public class FunctionalTests
{
    [Test]
    public void CountApplicationReturnsCorrect()
    {
        var functional = new Functional();
        int result = functional.CountApplication();
        Assert.That(Equals(2, result));
    }
        [Test]
        public void CountRolesReturnsCorrect()
        {
            var functional = new Functional();
            int result = functional.CountRoles();
            Assert.That(Equals(2, result));
        }
        [Test]
        public void CountUserReturnsCorrect()
        {
            var functional = new Functional();
            int result = functional.CountUser();
            Assert.That(Equals(2, result));
        }
    }

}