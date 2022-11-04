using System;
using System.Collections;

using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.X509;

namespace citronindo.cryptolib.bc.Pkcs
{
    public class X509CertificateEntry
        : Pkcs12Entry
    {
        private readonly X509Certificate cert;

		public X509CertificateEntry(
            X509Certificate cert)
			: base(Platform.CreateHashtable())
        {
            this.cert = cert;
        }

        public X509CertificateEntry(
            X509Certificate cert,
            IDictionary     attributes)
			: base(attributes)
        {
            this.cert = cert;
        }

		public X509Certificate Certificate
        {
			get { return this.cert; }
        }

		public override bool Equals(object obj)
		{
			X509CertificateEntry other = obj as X509CertificateEntry;

			if (other == null)
				return false;

			return cert.Equals(other.cert);
		}

		public override int GetHashCode()
		{
			return ~cert.GetHashCode();
		}
	}
}