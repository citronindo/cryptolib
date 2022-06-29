using System;
using citronindo.cryptolib.bc.Crypto;

namespace citronindo.cryptolib.bc.Crypto.Parameters
{
	/**
	* parameters for Key derivation functions for ISO-18033
	*/
	public class Iso18033KdfParameters
		: IDerivationParameters
	{
		byte[]  seed;

		public Iso18033KdfParameters(
			byte[]  seed)
		{
			this.seed = seed;
		}

		public byte[] GetSeed()
		{
			return seed;
		}
	}
}
