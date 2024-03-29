﻿using System;
using System.Collections;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Cms;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.X509;
using citronindo.cryptolib.bc.X509.Store;

namespace citronindo.cryptolib.bc.Cms
{
	public class OriginatorInformation
	{
		private readonly OriginatorInfo originatorInfo;

		internal OriginatorInformation(OriginatorInfo originatorInfo)
		{
			this.originatorInfo = originatorInfo;
		}

		/**
		* Return the certificates stored in the underlying OriginatorInfo object.
		*
		* @return a Store of X509CertificateHolder objects.
		*/
		public virtual IX509Store GetCertificates()
		{
			Asn1Set certSet = originatorInfo.Certificates;

			if (certSet != null)
			{
				IList certList = Platform.CreateArrayList(certSet.Count);

				foreach (Asn1Encodable enc in certSet)
				{
					Asn1Object obj = enc.ToAsn1Object();
					if (obj is Asn1Sequence)
					{
						certList.Add(new X509Certificate(X509CertificateStructure.GetInstance(obj)));
					}
				}

				return X509StoreFactory.Create(
					"Certificate/Collection",
					new X509CollectionStoreParameters(certList));
			}

			return X509StoreFactory.Create(
				"Certificate/Collection",
				new X509CollectionStoreParameters(Platform.CreateArrayList()));
		}

		/**
		* Return the CRLs stored in the underlying OriginatorInfo object.
		*
		* @return a Store of X509CRLHolder objects.
		*/
		public virtual IX509Store GetCrls()
		{
			Asn1Set crlSet = originatorInfo.Certificates;

			if (crlSet != null)
			{
                IList crlList = Platform.CreateArrayList(crlSet.Count);

				foreach (Asn1Encodable enc in crlSet)
				{
					Asn1Object obj = enc.ToAsn1Object();
					if (obj is Asn1Sequence)
					{
						crlList.Add(new X509Crl(CertificateList.GetInstance(obj)));
					}
				}

				return X509StoreFactory.Create(
					"CRL/Collection",
					new X509CollectionStoreParameters(crlList));
			}

			return X509StoreFactory.Create(
				"CRL/Collection",
                new X509CollectionStoreParameters(Platform.CreateArrayList()));
		}

		/**
		* Return the underlying ASN.1 object defining this SignerInformation object.
		*
		* @return a OriginatorInfo.
		*/
		public virtual OriginatorInfo ToAsn1Structure()
		{
			return originatorInfo;
		}
	}
}
