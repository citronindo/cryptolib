using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Frodo
{
    public class FrodoPublicKeyParameters
        : FrodoKeyParameters
    {

        public byte[] publicKey;

        public byte[] PublicKey => Arrays.Clone(publicKey);

        public byte[] GetEncoded()
        {
            return PublicKey;
        }

        public FrodoPublicKeyParameters(FrodoParameters parameters, byte[] publicKey)
            : base(false, parameters)
        {
            this.publicKey = Arrays.Clone(publicKey);
        }
    }
}