﻿using System;
using System.IO;
using System.Runtime.Serialization;

namespace citronindo.cryptolib.bc.Tls
{
	[Serializable]
	public class TlsTimeoutException
        : IOException
    {
		public TlsTimeoutException()
			: base()
		{
		}

		public TlsTimeoutException(string message)
			: base(message)
		{
		}

		public TlsTimeoutException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected TlsTimeoutException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
