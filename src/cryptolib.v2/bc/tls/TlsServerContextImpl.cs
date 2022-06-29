using System;

using citronindo.cryptolib.bc.Tls.Crypto;

namespace citronindo.cryptolib.bc.Tls
{
    internal class TlsServerContextImpl
        : AbstractTlsContext, TlsServerContext
    {
        internal TlsServerContextImpl(TlsCrypto crypto)
            : base(crypto, ConnectionEnd.server)
        {
        }

        public override bool IsServer
        {
            get { return true; }
        }
    }
}
