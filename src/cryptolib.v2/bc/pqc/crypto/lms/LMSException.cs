using System;
using System.Runtime.Serialization;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Lms
{
    [Serializable]
    public class LMSException
        : Exception
    {
		public LMSException()
			: base()
		{
		}

		public LMSException(string message)
			: base(message)
		{
		}

		public LMSException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected LMSException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
