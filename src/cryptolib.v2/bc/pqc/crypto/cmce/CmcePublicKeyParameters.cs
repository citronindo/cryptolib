using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Cmce
{
    public class CmcePublicKeyParameters
        : CmceKeyParameters
    {
        private byte[] publicKey;

        public byte[] PublicKey => Arrays.Clone(publicKey);

        public byte[] GetEncoded()
        {
            return PublicKey;
        }

        public CmcePublicKeyParameters(CmceParameters parameters, byte[] publicKey)
            : base(false,  parameters)
        {
            this.publicKey = Arrays.Clone(publicKey);
        }
    }
}