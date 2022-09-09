using System;
using System.Collections;

using citronindo.cryptolib.bc.Tls.Crypto;

namespace citronindo.cryptolib.bc.Tls
{
    public sealed class CertificateEntry
    {
        private readonly TlsCertificate m_certificate;
        private readonly IDictionary m_extensions;

        public CertificateEntry(TlsCertificate certificate, IDictionary extensions)
        {
            if (null == certificate)
                throw new ArgumentNullException("certificate");

            this.m_certificate = certificate;
            this.m_extensions = extensions;
        }

        public TlsCertificate Certificate
        {
            get { return m_certificate; }
        }

        public IDictionary Extensions
        {
            get { return m_extensions; }
        }
    }
}
