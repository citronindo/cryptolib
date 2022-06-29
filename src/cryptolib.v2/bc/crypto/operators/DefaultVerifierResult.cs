using System;

using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Crypto.Operators
{
    public class DefaultVerifierResult
        : IVerifier
    {
        private readonly ISigner mSigner;

        public DefaultVerifierResult(ISigner signer)
        {
            this.mSigner = signer;
        }

        public bool IsVerified(byte[] signature)
        {
            return mSigner.VerifySignature(signature);
        }

        public bool IsVerified(byte[] sig, int sigOff, int sigLen)
        {
            byte[] signature = Arrays.CopyOfRange(sig, sigOff, sigOff + sigLen);

            return IsVerified(signature);
        }
    }
}
