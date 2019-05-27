
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetExtensions.DataStructures.Tests
{
    [TestClass]
    public class RingBufferTests
    {
        [TestMethod]
        public void Test_Ring_Buffer()
        {
            var buffer = new RingBuffer<string>(3);
            buffer.Put("A");
            buffer.Put("B");
            Assert.AreEqual(buffer.Get().Count, 2);
            Assert.AreEqual(buffer.GetFirst(), "A");
            Assert.AreEqual(buffer.GetLast(), "B");

            buffer.Put("C");
            Assert.AreEqual(buffer.Get().Count, 3);
            Assert.AreEqual(buffer.GetFirst(), "A");
            Assert.AreEqual(buffer.GetLast(), "C");

            buffer.Put("D");
            Assert.AreEqual(buffer.Get().Count, 3);
            Assert.AreEqual(buffer.GetLast(), "D");
            Assert.AreEqual(buffer.GetFirst(), "B");
        }

        [TestMethod]
        public void Test_Concurrent_Ring_Buffer()
        {
            var buffer = new ConcurrentRingBuffer<string>(3);
            buffer.Put("A");
            buffer.Put("B");
            Assert.AreEqual(buffer.Get().Count, 2);
            Assert.AreEqual(buffer.GetFirst(), "A");
            Assert.AreEqual(buffer.GetLast(), "B");

            buffer.Put("C");
            Assert.AreEqual(buffer.Get().Count, 3);
            Assert.AreEqual(buffer.GetFirst(), "A");
            Assert.AreEqual(buffer.GetLast(), "C");

            buffer.Put("D");
            Assert.AreEqual(buffer.Get().Count, 3);
            Assert.AreEqual(buffer.GetLast(), "D");
            Assert.AreEqual(buffer.GetFirst(), "B");
        }
    }
}
