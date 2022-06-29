using System;
using System.IO;

namespace citronindo.cryptolib.bc.Tls.Crypto
{
    public interface TlsStreamSigner
    {
        /// <exception cref="IOException"/>
        Stream Stream { get; }

        /// <exception cref="IOException"/>
        byte[] GetSignature();
    }
}
