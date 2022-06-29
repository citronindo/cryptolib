using System;

namespace citronindo.cryptolib.bc.Cms
{
	internal interface IDigestCalculator
	{
		byte[] GetDigest();
	}
}
