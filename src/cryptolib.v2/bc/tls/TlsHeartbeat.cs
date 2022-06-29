using System;

namespace citronindo.cryptolib.bc.Tls
{
    public interface TlsHeartbeat
    {
        byte[] GeneratePayload();

        int IdleMillis { get; }

        int TimeoutMillis { get; }
    }
}
