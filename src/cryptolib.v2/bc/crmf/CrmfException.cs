using System;
using System.Runtime.Serialization;

namespace citronindo.cryptolib.bc.Crmf
{
	[Serializable]
	public class CrmfException
        : Exception
    {
		public CrmfException()
			: base()
		{
		}

		public CrmfException(string message)
			: base(message)
		{
		}

		public CrmfException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected CrmfException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
