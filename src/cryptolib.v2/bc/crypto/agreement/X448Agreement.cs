using System;

using citronindo.cryptolib.bc.Crypto.Parameters;

namespace citronindo.cryptolib.bc.Crypto.Agreement
{
    public sealed class X448Agreement
        : IRawAgreement
    {
        private X448PrivateKeyParameters privateKey;

        public void Init(ICipherParameters parameters)
        {
            this.privateKey = (X448PrivateKeyParameters)parameters;
        }

        public int AgreementSize
        {
            get { return X448PrivateKeyParameters.SecretSize; }
        }

        public void CalculateAgreement(ICipherParameters publicKey, byte[] buf, int off)
        {
            privateKey.GenerateSecret((X448PublicKeyParameters)publicKey, buf, off);
        }
    }
}
