using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Math.EC;

namespace citronindo.cryptolib.bc.Bcpg
{
    /// <remarks>Base class for an ECDSA Public Key.</remarks>
    public class ECDsaPublicBcpgKey
        : ECPublicBcpgKey
    {
        /// <param name="bcpgIn">The stream to read the packet from.</param>
        protected internal ECDsaPublicBcpgKey(
            BcpgInputStream bcpgIn)
            : base(bcpgIn)
        {
        }

        public ECDsaPublicBcpgKey(
            DerObjectIdentifier oid,
            ECPoint point)
            : base(oid, point)
        {
        }

        public ECDsaPublicBcpgKey(
            DerObjectIdentifier oid,
            BigInteger encodedPoint)
            : base(oid, encodedPoint)
        {
        }
    }
}
