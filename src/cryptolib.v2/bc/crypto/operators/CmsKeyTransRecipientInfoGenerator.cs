using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Cms;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Cms;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.X509;

namespace citronindo.cryptolib.bc.Operators
{
    /// <deprecated>Use KeyTransRecipientInfoGenerator</deprecated>
    public class CmsKeyTransRecipientInfoGenerator
        : KeyTransRecipientInfoGenerator
    {
        public CmsKeyTransRecipientInfoGenerator(X509Certificate recipCert, IKeyWrapper keyWrapper)
            : base(new Asn1.Cms.IssuerAndSerialNumber(recipCert.IssuerDN, new DerInteger(recipCert.SerialNumber)), keyWrapper)
        {
        }

        public CmsKeyTransRecipientInfoGenerator(IssuerAndSerialNumber issuerAndSerial, IKeyWrapper keyWrapper)
            : base(issuerAndSerial, keyWrapper)
        {
        }

        public CmsKeyTransRecipientInfoGenerator(byte[] subjectKeyID, IKeyWrapper keyWrapper) : base(subjectKeyID, keyWrapper)
        {
        }
    }
}
