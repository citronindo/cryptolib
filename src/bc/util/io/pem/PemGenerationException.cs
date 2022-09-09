using System;
using System.Runtime.Serialization;

namespace citronindo.cryptolib.bc.Utilities.IO.Pem
{
    [Serializable]
    public class PemGenerationException
		: Exception
	{
		public PemGenerationException()
			: base()
		{
		}

		public PemGenerationException(string message)
			: base(message)
		{
		}

		public PemGenerationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected PemGenerationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
