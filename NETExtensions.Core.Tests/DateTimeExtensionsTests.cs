using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.String.Test
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void DateTime_IsValid()
        {
            DateTime dateTime = DateTime.Now;

            Assert.IsTrue(dateTime.IsValid());
        }

        [TestMethod]
        public void DateTime_IsNotValid()
        {
            DateTime dateTime = DateTime.MinValue;

            Assert.IsTrue(dateTime.IsNotValid());
        }

        [TestMethod]
        public void DateTime_InRange()
        {
            var minDate = DateTime.Now.AddHours(-1);
            var maxDate = DateTime.Now.AddHours(1);

            DateTime dateTime = DateTime.Now;

            Assert.IsTrue(dateTime.InRange(minDate,maxDate));
        }

        [TestMethod]
        public void DateTime_NotInRange()
        {
            var minDate = DateTime.Now.AddHours(1);
            var maxDate = DateTime.Now.AddHours(2);

            DateTime dateTime = DateTime.Now;

            Assert.IsTrue(dateTime.NotInRange(minDate, maxDate));
        }

        [TestMethod]
        public void DateTime_WithDateTimeKind()
        {
            DateTime dateTime = DateTime.Now;
            var newDateTime = dateTime.WithDateTimeKind(DateTimeKind.Local);
            Assert.AreEqual(DateTimeKind.Local, newDateTime.Value.Kind);
        }
    }
}
