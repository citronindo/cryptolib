using System;
using System.Collections;
using System.IO;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Operators;
using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Security;
using citronindo.cryptolib.bc.Security.Certificates;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Utilities.Collections;

namespace citronindo.cryptolib.bc.X509
{
	/**
	* class to produce an X.509 Version 2 CRL.
	*/
	public class X509V2CrlGenerator
	{
		private readonly X509ExtensionsGenerator extGenerator = new X509ExtensionsGenerator();

		private V2TbsCertListGenerator tbsGen;

		public X509V2CrlGenerator()
		{
			tbsGen = new V2TbsCertListGenerator();
		}

		/**
		* reset the generator
		*/
		public void Reset()
		{
			tbsGen = new V2TbsCertListGenerator();
			extGenerator.Reset();
		}

		/**
		* Set the issuer distinguished name - the issuer is the entity whose private key is used to sign the
		* certificate.
		*/
		public void SetIssuerDN(
			X509Name issuer)
		{
			tbsGen.SetIssuer(issuer);
		}

		public void SetThisUpdate(
			DateTime date)
		{
			tbsGen.SetThisUpdate(new Time(date));
		}

		public void SetNextUpdate(
			DateTime date)
		{
			tbsGen.SetNextUpdate(new Time(date));
		}

		/**
		* Reason being as indicated by CrlReason, i.e. CrlReason.KeyCompromise
		* or 0 if CrlReason is not to be used
		**/
		public void AddCrlEntry(
			BigInteger	userCertificate,
			DateTime	revocationDate,
			int			reason)
		{
			tbsGen.AddCrlEntry(new DerInteger(userCertificate), new Time(revocationDate), reason);
		}

		/**
		* Add a CRL entry with an Invalidity Date extension as well as a CrlReason extension.
		* Reason being as indicated by CrlReason, i.e. CrlReason.KeyCompromise
		* or 0 if CrlReason is not to be used
		**/
		public void AddCrlEntry(
			BigInteger	userCertificate,
			DateTime	revocationDate,
			int			reason,
			DateTime	invalidityDate)
		{
			tbsGen.AddCrlEntry(new DerInteger(userCertificate), new Time(revocationDate), reason, new DerGeneralizedTime(invalidityDate));
		}

		/**
		* Add a CRL entry with extensions.
		**/
		public void AddCrlEntry(
			BigInteger		userCertificate,
			DateTime		revocationDate,
			X509Extensions	extensions)
		{
			tbsGen.AddCrlEntry(new DerInteger(userCertificate), new Time(revocationDate), extensions);
		}

		/**
		* Add the CRLEntry objects contained in a previous CRL.
		*
		* @param other the X509Crl to source the other entries from.
		*/
		public void AddCrl(
			X509Crl other)
		{
			if (other == null)
				throw new ArgumentNullException("other");

			ISet revocations = other.GetRevokedCertificates();

			if (revocations != null)
			{
				foreach (X509CrlEntry entry in revocations)
				{
					try
					{
						tbsGen.AddCrlEntry(
							Asn1Sequence.GetInstance(
							Asn1Object.FromByteArray(entry.GetEncoded())));
					}
					catch (IOException e)
					{
						throw new CrlException("exception processing encoding of CRL", e);
					}
				}
			}
		}

		/**
		* add a given extension field for the standard extensions tag (tag 0)
		*/
		public void AddExtension(
			string			oid,
			bool			critical,
			Asn1Encodable	extensionValue)
		{
			extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
		}

		/**
		* add a given extension field for the standard extensions tag (tag 0)
		*/
		public void AddExtension(
			DerObjectIdentifier	oid,
			bool				critical,
			Asn1Encodable		extensionValue)
		{
			extGenerator.AddExtension(oid, critical, extensionValue);
		}

		/**
		* add a given extension field for the standard extensions tag (tag 0)
		*/
		public void AddExtension(
			string	oid,
			bool	critical,
			byte[]	extensionValue)
		{
			extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, new DerOctetString(extensionValue));
		}

		/**
		* add a given extension field for the standard extensions tag (tag 0)
		*/
		public void AddExtension(
			DerObjectIdentifier	oid,
			bool				critical,
			byte[]				extensionValue)
		{
			extGenerator.AddExtension(oid, critical, new DerOctetString(extensionValue));
		}

        /// <summary>
        /// Generate a new X509Crl using the passed in SignatureCalculator.
        /// </summary>
		/// <param name="signatureCalculatorFactory">A signature calculator factory with the necessary algorithm details.</param>
        /// <returns>An X509Crl.</returns>
        public X509Crl Generate(ISignatureFactory signatureCalculatorFactory)
        {
            tbsGen.SetSignature((AlgorithmIdentifier)signatureCalculatorFactory.AlgorithmDetails);

            TbsCertificateList tbsCertList = GenerateCertList();

            IStreamCalculator streamCalculator = signatureCalculatorFactory.CreateCalculator();

            byte[] encoded = tbsCertList.GetDerEncoded();

            streamCalculator.Stream.Write(encoded, 0, encoded.Length);

            Platform.Dispose(streamCalculator.Stream);

            return GenerateJcaObject(tbsCertList, (AlgorithmIdentifier)signatureCalculatorFactory.AlgorithmDetails, ((IBlockResult)streamCalculator.GetResult()).Collect());
        }

        private TbsCertificateList GenerateCertList()
		{
			if (!extGenerator.IsEmpty)
			{
				tbsGen.SetExtensions(extGenerator.Generate());
			}

			return tbsGen.GenerateTbsCertList();
		}

		private X509Crl GenerateJcaObject(
			TbsCertificateList	tbsCrl,
            AlgorithmIdentifier algId,
			byte[]				signature)
		{
			return new X509Crl(
				CertificateList.GetInstance(
					new DerSequence(tbsCrl, algId, new DerBitString(signature))));
		}

		/// <summary>
		/// Allows enumeration of the signature names supported by the generator.
		/// </summary>
		public IEnumerable SignatureAlgNames
		{
			get { return X509Utilities.GetAlgNames(); }
		}
	}
}
