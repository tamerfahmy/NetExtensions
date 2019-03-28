using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.String.Test
{
    [TestClass]
    public class NumberExtesionsTests
    {
        [TestMethod]
        public void Int_InRange()
        {
            int number = 4;

            Assert.IsTrue(number.InRange(1,5));
        }

        [TestMethod]
        public void Int_NotInRange()
        {
            int number = 4;

            Assert.IsTrue(number.NotInRange(1, 2));
        }

        [TestMethod]
        public void Decimal_NotInRange()
        {
            decimal number = 4.1m;

            Assert.IsTrue(number.NotInRange(4.0m, 4.09m));
        }
    }
}
