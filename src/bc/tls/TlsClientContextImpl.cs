using System;

using citronindo.cryptolib.bc.Tls.Crypto;

namespace citronindo.cryptolib.bc.Tls
{
    internal class TlsClientContextImpl
        : AbstractTlsContext, TlsClientContext
    {
        internal TlsClientContextImpl(TlsCrypto crypto)
            : base(crypto, ConnectionEnd.client)
        {
        }

        public override bool IsServer
        {
            get { return false; }
        }
    }
}
