using System;

using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.X509.Store;

namespace citronindo.cryptolib.bc.Cms
{
    /**
    * a basic index for a signer.
    */
    public class SignerID
        : X509CertStoreSelector
    {
        public override int GetHashCode()
        {
            int code = Arrays.GetHashCode(this.SubjectKeyIdentifier);

			BigInteger serialNumber = this.SerialNumber;
			if (serialNumber != null)
            {
                code ^= serialNumber.GetHashCode();
            }

			X509Name issuer = this.Issuer;
            if (issuer != null)
            {
                code ^= issuer.GetHashCode();
            }

			return code;
        }

        public override bool Equals(
            object obj)
        {
			if (obj == this)
				return false;

			SignerID id = obj as SignerID;

			if (id == null)
				return false;

			return Arrays.AreEqual(SubjectKeyIdentifier, id.SubjectKeyIdentifier)
				&& Platform.Equals(SerialNumber, id.SerialNumber)
				&& IssuersMatch(Issuer, id.Issuer);
        }
    }
}
