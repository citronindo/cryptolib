using System;

using citronindo.cryptolib.bc.Asn1.Cmp;
using citronindo.cryptolib.bc.Cms;

namespace citronindo.cryptolib.bc.Cmp
{
    public class CertificateConfirmationContent
    {
        private readonly DefaultDigestAlgorithmIdentifierFinder digestAlgFinder;
        private readonly CertConfirmContent content;

        public CertificateConfirmationContent(CertConfirmContent content)
        {
            this.content = content;
        }

        public CertificateConfirmationContent(CertConfirmContent content,
            DefaultDigestAlgorithmIdentifierFinder digestAlgFinder)
        {
            this.content = content;
            this.digestAlgFinder = digestAlgFinder;
        }

        public CertConfirmContent ToAsn1Structure()
        {
            return content;
        }

        public CertificateStatus[] GetStatusMessages()
        {
            CertStatus[] statusArray = content.ToCertStatusArray();
            CertificateStatus[] ret = new CertificateStatus[statusArray.Length];
            for (int i = 0; i != ret.Length; i++)
            {
                ret[i] = new CertificateStatus(digestAlgFinder, statusArray[i]);
            }

            return ret;
        }
    }
}
