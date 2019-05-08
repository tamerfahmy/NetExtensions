using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.StringConversion.Test
{
    [TestClass]
    public class StringConversionTests
    {
        [TestMethod]
        public void String_ToShort_Null()
        {
            string source = null;

            Assert.IsNull(source.ToShort());
        }

        [TestMethod]
        public void String_ToShort()
        {
            string source = "1";
            short value = 1;

            Assert.AreEqual(value, source.ToShort());
        }

        [TestMethod]
        public void String_ToInt()
        {
            string source = "1";
            int value = 1;

            Assert.AreEqual(value, source.ToInt());
        }

        [TestMethod]
        public void String_ToLong()
        {
            string source = "1";
            long value = 1;

            Assert.AreEqual(value, source.ToLong());
        }

        [TestMethod]
        public void String_ToDecimal()
        {
            string source = "1.1";
            Decimal value = 1.1M;

            Assert.AreEqual(value, source.ToDecimal());
        }

        [TestMethod]
        public void String_ToDouble()
        {
            string source = "1.01";
            Double value = 1.01d;

            Assert.AreEqual(value, source.ToDouble());
        }

        [TestMethod]
        public void String_ToFloat()
        {
            string source = "1.05123";
            float value = 1.05123f;

            Assert.AreEqual(value, source.ToFloat());
        }

        [TestMethod]
        public void String_ToBool_From_True_String()
        {
            string source = "true";
            bool value = true;

            Assert.AreEqual(value, source.ToBool());
        }

        [TestMethod]
        public void String_ToBool_From_Binary_01()
        {
            string source = "0";
            bool value = false;

            Assert.AreEqual(value, source.ToBool());
        }

        [TestMethod]
        public void String_ToBool_From_Binary_01_WithWhiteSpace()
        {
            string source = "1 ";
            bool value = true;

            Assert.AreEqual(value, source.ToBool());
        }

        [TestMethod]
        public void String_ToByte()
        {
            string source = "1";
            byte value = 1;

            Assert.AreEqual(value, source.ToByte());
        }

        [TestMethod]
        public void String_ToDateTime()
        {
            DateTime value = DateTime.Now;
            string source = value.ToString();
            Assert.AreEqual(1, value.CompareTo(source.ToDateTime().Value));

            Assert.AreEqual(value.Year, source.ToDateTime().Value.Year);
            Assert.AreEqual(value.Month, source.ToDateTime().Value.Month);
            Assert.AreEqual(value.Day, source.ToDateTime().Value.Day);
            Assert.AreEqual(value.Hour, source.ToDateTime().Value.Hour);
            Assert.AreEqual(value.Minute, source.ToDateTime().Value.Minute);
            Assert.AreEqual(value.Second, source.ToDateTime().Value.Second);
        }

        [TestMethod]
        public void String_ToDateTime_WithDateTimeKind()
        {
            DateTime value = DateTime.Now;
            string source = value.ToString();
            Assert.AreEqual(1, value.CompareTo(source.ToDateTime().Value));

            Assert.AreEqual(value.Kind, source.ToDateTime(value.Kind).Value.Kind);
        }

        [TestMethod]
        public void String_ToEnum_Invalid_Null()
        {
            string utc = null;
            Assert.AreEqual(false, utc.ToEnum<DateTimeKind>().HasValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Requested value 'Invalid' was not found")]
        public void String_ToEnum_Invalid()
        {
            string utc = "Invalid";
            Assert.AreNotEqual(DateTimeKind.Utc, utc.ToEnum<DateTimeKind>());
        }

        [TestMethod]
        public void String_ToEnum()
        {
            string utc = DateTimeKind.Utc.ToString();
            Assert.AreEqual(DateTimeKind.Utc, utc.ToEnum<DateTimeKind>().Value);
        }

        [TestMethod]
        public void String_ToGuid()
        {
            Guid guid = Guid.NewGuid();
            Assert.AreEqual(guid, guid.ToString().ToGuid().Value);
        }
    }
}
