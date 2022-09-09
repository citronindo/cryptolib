using System;

using citronindo.cryptolib.bc.Crypto.Parameters;

namespace citronindo.cryptolib.bc.Crypto.Agreement
{
    public sealed class X25519Agreement
        : IRawAgreement
    {
        private X25519PrivateKeyParameters privateKey;

        public void Init(ICipherParameters parameters)
        {
            this.privateKey = (X25519PrivateKeyParameters)parameters;
        }

        public int AgreementSize
        {
            get { return X25519PrivateKeyParameters.SecretSize; }
        }

        public void CalculateAgreement(ICipherParameters publicKey, byte[] buf, int off)
        {
            privateKey.GenerateSecret((X25519PublicKeyParameters)publicKey, buf, off);
        }
    }
}
