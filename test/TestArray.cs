using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace citronlib.test
{
    [TestClass]
	public class TestArray
	{
        [TestMethod]
		public void TestSpan()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Span<byte> dest = stackalloc byte[source.Length];

            source[..3].AsSpan().CopyTo(dest[5..]);

            CollectionAssert.AreEqual(dest[5..(5+3)].ToArray(), source[..3]);
        }
	}
}

