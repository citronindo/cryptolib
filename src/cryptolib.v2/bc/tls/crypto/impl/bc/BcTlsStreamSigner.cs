using System;
using System.IO;

using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.IO;

namespace citronindo.cryptolib.bc.Tls.Crypto.Impl.BC
{
    internal sealed class BcTlsStreamSigner
        : TlsStreamSigner
    {
        private readonly SignerSink m_output;

        internal BcTlsStreamSigner(ISigner signer)
        {
            this.m_output = new SignerSink(signer);
        }

        public Stream Stream
        {
            get { return m_output; }
        }

        public byte[] GetSignature()
        {
            try
            {
                return m_output.Signer.GenerateSignature();
            }
            catch (CryptoException e)
            {
                throw new TlsFatalAlert(AlertDescription.internal_error, e);
            }
        }
    }
}
