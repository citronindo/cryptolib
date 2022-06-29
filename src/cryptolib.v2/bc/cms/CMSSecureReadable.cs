using System;

using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto.Parameters;

namespace citronindo.cryptolib.bc.Cms
{
	internal interface CmsSecureReadable
	{
		AlgorithmIdentifier Algorithm { get; }
		object CryptoObject { get; }
		CmsReadable GetReadable(KeyParameter key);
	}
}
