using System;

using citronindo.cryptolib.bc.Tls.Crypto;

namespace citronindo.cryptolib.bc.Tls
{
    public interface TlsPsk
    {
        byte[] Identity { get; }

        TlsSecret Key { get; }

        int PrfAlgorithm { get; }
    }
}
