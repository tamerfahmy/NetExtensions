using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.NumberExtesion.Test
{
    [TestClass]
    public class NumberExtesionsTests
    {
        [TestMethod]
        public void Int_InRange()
        {
            int number = 4;

            Assert.IsTrue(number.InRange(1, 5));
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

        [TestMethod]
        public void Int_NextRandom()
        {
            int minNumber = 10;
            var randomNumber1 = minNumber.NextRandom(20);

            Assert.IsTrue(randomNumber1 >= 10);
            Assert.IsTrue(randomNumber1 <= 20);

            var randomNumber2 = minNumber.NextRandom(20);
            Assert.IsTrue(randomNumber2 >= 10);
            Assert.IsTrue(randomNumber2 <= 20);
            Assert.IsTrue(randomNumber1 != randomNumber2);
        }
    }
}
