using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Saber
{
    public class SABERPrivateKeyParameters
        : SABERKeyParameters
    {
        private byte[] privateKey;

        public byte[] GetPrivateKey()
        {
            return Arrays.Clone(privateKey);
        }

        public SABERPrivateKeyParameters(SABERParameters parameters, byte[] privateKey)
            : base(true, parameters)
        {
            this.privateKey = Arrays.Clone(privateKey);
        }

        public byte[] GetEncoded()
        {
            return Arrays.Clone(privateKey);
        }
    }
}