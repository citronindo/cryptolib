using System;

namespace citronindo.cryptolib.bc.Tls
{
    /// <summary>Server certificate carrier interface.</summary>
    public interface TlsServerCertificate
    {
        Certificate Certificate { get; }

        CertificateStatus CertificateStatus { get; }
    }
}
