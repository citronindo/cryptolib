using System;
using System.IO;

using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.IO;

namespace citronindo.cryptolib.bc.Tls.Crypto.Impl.BC
{
    internal sealed class BcTls13Verifier
        : Tls13Verifier
    {
        private readonly SignerSink m_output;

        internal BcTls13Verifier(ISigner verifier)
        {
            if (verifier == null)
                throw new ArgumentNullException("verifier");

            this.m_output = new SignerSink(verifier);
        }

        public Stream Stream
        {
            get { return m_output; }
        }

        public bool VerifySignature(byte[] signature)
        {
            return m_output.Signer.VerifySignature(signature);
        }
    }
}
