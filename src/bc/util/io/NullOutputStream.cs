using System;

namespace citronindo.cryptolib.bc.Utilities.IO
{
	internal class NullOutputStream
		: BaseOutputStream
	{
		public override void Write(byte[] buffer, int offset, int count)
		{
			Streams.ValidateBufferArguments(buffer, offset, count);
		}

		public override void WriteByte(byte value)
		{
		}
	}
}
