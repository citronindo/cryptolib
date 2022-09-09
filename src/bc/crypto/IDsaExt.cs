using System;

using citronindo.cryptolib.bc.Math;

namespace citronindo.cryptolib.bc.Crypto
{
    /// <summary>
    /// An "extended" interface for classes implementing DSA-style algorithms, that provides access
    /// to the group order.
    /// </summary>
    public interface IDsaExt
        : IDsa
    {
        /// <summary>The order of the group that the r, s values in signatures belong to.</summary>
        BigInteger Order { get; }
    }
}
