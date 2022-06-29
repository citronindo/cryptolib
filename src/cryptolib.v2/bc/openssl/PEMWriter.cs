using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.CryptoPro;
using citronindo.cryptolib.bc.Asn1.Pkcs;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Asn1.X9;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Generators;
using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Pkcs;
using citronindo.cryptolib.bc.Security;
using citronindo.cryptolib.bc.Security.Certificates;
using citronindo.cryptolib.bc.Utilities.Encoders;
using citronindo.cryptolib.bc.Utilities.IO.Pem;
using citronindo.cryptolib.bc.X509;

namespace citronindo.cryptolib.bc.OpenSsl
{
	/// <remarks>General purpose writer for OpenSSL PEM objects.</remarks>
	public class PemWriter
		: citronindo.cryptolib.bc.Utilities.IO.Pem.PemWriter
	{
		/// <param name="writer">The TextWriter object to write the output to.</param>
		public PemWriter(
			TextWriter writer)
			: base(writer)
		{
		}

		public void WriteObject(
			object obj) 
		{
			try
			{
				base.WriteObject(new MiscPemGenerator(obj));
			}
			catch (PemGenerationException e)
			{
				if (e.InnerException is IOException)
					throw (IOException)e.InnerException;

				throw e;
			}
		}

		public void WriteObject(
			object			obj,
			string			algorithm,
			char[]			password,
			SecureRandom	random)
		{
			base.WriteObject(new MiscPemGenerator(obj, algorithm, password, random));
		}
	}
}
