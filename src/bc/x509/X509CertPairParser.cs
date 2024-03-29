using System;
using System.Collections;
using System.IO;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Security.Certificates;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.X509
{
	public class X509CertPairParser
	{
		private Stream currentStream;

		private X509CertificatePair ReadDerCrossCertificatePair(
			Stream inStream)
		{
			Asn1InputStream dIn = new Asn1InputStream(inStream);//, ProviderUtil.getReadLimit(in));
			Asn1Sequence seq = (Asn1Sequence)dIn.ReadObject();
			CertificatePair pair = CertificatePair.GetInstance(seq);
			return new X509CertificatePair(pair);
		}

		/// <summary>
		/// Create loading data from byte array.
		/// </summary>
		/// <param name="input"></param>
		public X509CertificatePair ReadCertPair(
			byte[] input)
		{
			return ReadCertPair(new MemoryStream(input, false));
		}

		/// <summary>
		/// Create loading data from byte array.
		/// </summary>
		/// <param name="input"></param>
		public ICollection ReadCertPairs(
			byte[] input)
		{
			return ReadCertPairs(new MemoryStream(input, false));
		}

		public X509CertificatePair ReadCertPair(
			Stream inStream)
		{
			if (inStream == null)
				throw new ArgumentNullException("inStream");
			if (!inStream.CanRead)
				throw new ArgumentException("inStream must be read-able", "inStream");

			if (currentStream == null)
			{
				currentStream = inStream;
			}
			else if (currentStream != inStream) // reset if input stream has changed
			{
				currentStream = inStream;
			}

			try
			{
                int tag = inStream.ReadByte();
                if (tag < 0)
                    return null;

                if (inStream.CanSeek)
                {
                    inStream.Seek(-1L, SeekOrigin.Current);
                }
                else
                {
                    PushbackStream pis = new PushbackStream(inStream);
                    pis.Unread(tag);
                    inStream = pis;
                }

                return ReadDerCrossCertificatePair(inStream);
			}
			catch (Exception e)
			{
				throw new CertificateException(e.ToString());
			}
		}

		public ICollection ReadCertPairs(
			Stream inStream)
		{
			X509CertificatePair certPair;
			IList certPairs = Platform.CreateArrayList();

			while ((certPair = ReadCertPair(inStream)) != null)
			{
				certPairs.Add(certPair);
			}

			return certPairs;
		}
	}
}
