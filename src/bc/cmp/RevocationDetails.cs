using System;

using citronindo.cryptolib.bc.Asn1.Cmp;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Math;

namespace citronindo.cryptolib.bc.Cmp
{
    public class RevocationDetails
    {
        private readonly RevDetails revDetails;

        public RevocationDetails(RevDetails revDetails)
        {
            this.revDetails = revDetails;
        }

        public X509Name Subject
        {
            get { return revDetails.CertDetails.Subject; }
        }

        public X509Name Issuer
        {
            get { return revDetails.CertDetails.Issuer; }
        }

        public BigInteger SerialNumber
        {
            get { return revDetails.CertDetails.SerialNumber.Value; }
        }

        public RevDetails ToASN1Structure()
        {
            return revDetails;
        }
    }
}
