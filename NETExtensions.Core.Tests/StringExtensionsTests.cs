using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.String.Test
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void String_IsNull()
        {
            string source = null;

            Assert.IsTrue(source.IsNull());
        }

        [TestMethod]
        public void String_Null_String_IsEmpty()
        {
            string source = null;

            Assert.IsTrue(source.IsEmpty());
        }

        [TestMethod]
        public void String_IsEmpty()
        {
            string source = string.Empty;

            Assert.IsTrue(source.IsEmpty());
        }

        [TestMethod]
        public void String_IsEmpty_Empty_Stirng()
        {
            string source = "";

            Assert.IsTrue(source.IsEmpty());
        }

        [TestMethod]
        public void String_IsEmpty_Ignore_White_Space()
        {
            string source = " ";

            Assert.IsTrue(source.IsEmpty());
        }

        [TestMethod]
        public void String_IsEmpty_Dont_Ignore_White_Space()
        {
            string source = " ";

            Assert.IsFalse(source.IsEmpty(false));
        }

        [TestMethod]
        public void String_IsNullOrEmpty_Null()
        {
            string source = null;

            Assert.IsTrue(source.IsNullOrEmpty());
        }

        [TestMethod]
        public void String_IsNullOrEmpty_Empty()
        {
            string source = "";

            Assert.IsTrue(source.IsNullOrEmpty());
        }

        [TestMethod]
        public void String_FormatWith()
        {
            string source = "This is an {0}";

            Assert.AreEqual("This is an example", source.FormatWith("example"));
        }

        [TestMethod]
        public void String_FormatWith_With_Null_String()
        {
            string source = null;

            Assert.AreEqual(null, source.FormatWith("example"));
        }

        [TestMethod]
        public void String_FormatWith_Less_PlaceHolders()
        {
            string source = "This is an ";

            Assert.AreEqual("This is an ", source.FormatWith("example"));
        }

        [TestMethod]
        public void String_FormatWith_Extra_Parameters()
        {
            string source = "This is an {0}";

            Assert.AreEqual("This is an example", source.FormatWith("example", "Extra"));
        }

        [TestMethod]
        public void String_IsEmail_Valid()
        {
            string source = "1test123@test00.com";

            Assert.IsTrue(source.IsEmail());
        }

        [TestMethod]
        public void String_IsEmail_Null_Invalid()
        {
            string source = null;

            Assert.IsFalse(source.IsEmail());
        }

        [TestMethod]
        public void String_IsEmail_Invalid()
        {
            string source = "1test123@test00.com1";

            Assert.IsFalse(source.IsEmail());
        }

        [TestMethod]
        public void String_IsNumber_Valid()
        {
            string source = "1234";

            Assert.IsTrue(source.IsNumber());
        }

        [TestMethod]
        public void String_IsNumber_Invalid_Null()
        {
            string source = null;

            Assert.IsFalse(source.IsNumber());
        }

        [TestMethod]
        public void String_IsNumber_Invalid()
        {
            string source = "a 123";

            Assert.IsFalse(source.IsNumber());
        }

        [TestMethod]
        public void String_IsNumber_Valid_With_WhiteSpaces()
        {
            string source = " 123  ";

            Assert.IsTrue(source.IsNumber());
        }

        [TestMethod]
        public void String_IsNumber_Invalid_With_WhiteSpaces()
        {
            string source = " 123 ";

            Assert.IsFalse(source.IsNumber(false));
        }

        [TestMethod]
        public void String_TakeRight()
        {
            string source = "12345";

            Assert.AreEqual("45", source.TakeRight(2));
        }

        [TestMethod]
        public void String_TakeLeft()
        {
            string source = "12345";

            Assert.AreEqual("12", source.TakeLeft(2));
        }

        [TestMethod]
        public void String_ConcatWith()
        {
            string source = "1";
            var otherStrings = new string[] { "23", "45" };

            Assert.AreEqual("12345", source.ConcatWith(otherStrings));
        }

        [TestMethod]
        public void String_Concatenate_List()
        {
            var stringCollection = new System.Collections.Generic.List<string> { "23", "45" };

            Assert.AreEqual("2345", stringCollection.Concatenate());
        }

        [TestMethod]
        public void String_Concatenate_List_WithSeparator()
        {
            var stringCollection = new System.Collections.Generic.List<string> { "23", "45" };

            Assert.AreEqual("23,45", stringCollection.Concatenate(","));
        }
    }
}
