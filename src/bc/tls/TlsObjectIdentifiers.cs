using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.X509;

namespace citronindo.cryptolib.bc.Tls
{
    /// <summary>Object Identifiers associated with TLS extensions.</summary>
    public abstract class TlsObjectIdentifiers
    {
        /// <summary>RFC 7633</summary>
        public static readonly DerObjectIdentifier id_pe_tlsfeature = X509ObjectIdentifiers.IdPE.Branch("24");
    }
}
