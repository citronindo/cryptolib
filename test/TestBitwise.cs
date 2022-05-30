using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace citronlib.test
{
    [TestClass]
	public class Bitwise
	{
        [TestMethod]
		public void BitwiseSample()
        {
            var a = 0b_1100;
            var b = 0b_1010;
            var and = a & b;
            var res = 8;

            Assert.IsTrue(and == 0b_1000);
            Assert.IsTrue(res == and);

            var or = a | b;
            res = 14;

            Assert.IsTrue(or == 0b_1110);
            Assert.IsTrue(res == or);

            var xor = a ^ b;
            res = 6;

            Assert.IsTrue(xor == 0b_0110);
            Assert.IsTrue(res == xor);

            var not = ~a;
            res = -13;

            Assert.IsTrue(not == unchecked((int)0b_1111_1111_1111_1111_1111_1111_1111_0011));
            Assert.IsTrue(res == not);

            var left = a << 2;
            var str = Convert.ToString(left, 2);
            res = 48;

            Assert.IsTrue(left == 0b_0011_0000);
            Assert.IsTrue(res == left);

            var right = a >> 2;
            str = Convert.ToString(right, 2);
            res = 3;

            Assert.IsTrue(right == 0b_0011);
            Assert.IsTrue(res == right);
        }
    }
}

