using System;
using System.Runtime.Serialization;

namespace citronindo.cryptolib.bc.Bcpg
{
    [Serializable]
    public class UnsupportedPacketVersionException
        : Exception
    {
		public UnsupportedPacketVersionException()
			: base()
		{
		}

		public UnsupportedPacketVersionException(string message)
			: base(message)
		{
		}

		public UnsupportedPacketVersionException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected UnsupportedPacketVersionException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
    }
}
