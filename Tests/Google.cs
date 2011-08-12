using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google;

namespace Tests
{
    [TestFixture()]
    public class Google
    {
        [Test]
        public void TestPreposicao()
        {
                      
            int count = Googlon.ContarPreposicoes("tgprws xdcq nrh");
            Assert.AreEqual(20, count);
        }
    }
}
