using System;

using citronindo.cryptolib.bc.Asn1;

namespace citronindo.cryptolib.bc.Crmf
{
    /// <summary>
    /// Generic interface for a CertificateRequestMessage control value.
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Return the type of this control.
        /// </summary>
        DerObjectIdentifier Type { get; }

        /// <summary>
        /// Return the value contained in this control object.
        /// </summary>
        Asn1Encodable Value { get; }
    }
}
