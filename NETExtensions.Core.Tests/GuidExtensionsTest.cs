using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.GuidExtension.Test
{
    [TestClass]
    public class GuidExtensionsTest
    {
        [TestMethod]
        public void Guid_IsValid()
        {
            Guid guid = Guid.NewGuid();

            Assert.IsTrue(guid.IsValid());
        }

        [TestMethod]
        public void Guid_IsNotValid()
        {
            Guid guid = Guid.Empty;

            Assert.IsTrue(guid.IsNotValid());
        }
    }
}
