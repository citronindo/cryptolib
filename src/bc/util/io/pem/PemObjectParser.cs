using System;
using System.IO;

namespace citronindo.cryptolib.bc.Utilities.IO.Pem
{
	public interface PemObjectParser
	{
		/// <param name="obj">
		/// A <see cref="PemObject"/>
		/// </param>
		/// <returns>
		/// An <see cref="object"/>
		/// </returns>
		/// <exception cref="IOException"></exception>
		object ParseObject(PemObject obj);
	}
}
