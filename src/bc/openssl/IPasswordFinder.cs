using System;

namespace citronindo.cryptolib.bc.OpenSsl
{
	public interface IPasswordFinder
	{
		char[] GetPassword();
	}
}
