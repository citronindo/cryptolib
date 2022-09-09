using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cryptolib.test
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

        [TestMethod]
        public void TestRandom()
        {
            Random rnd = new();
            var sc = string.Join("", DateTime.Now.ToString("yyMMdd"), rnd.Next(1000, 9999));
        }
    }
}

