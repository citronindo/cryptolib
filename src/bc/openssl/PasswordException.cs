using System;
using System.IO;
using System.Runtime.Serialization;

namespace citronindo.cryptolib.bc.Security
{
    [Serializable]
    public class PasswordException
		: IOException
	{
		public PasswordException()
			: base()
		{
		}

		public PasswordException(string message)
			: base(message)
		{
		}

		public PasswordException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected PasswordException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
