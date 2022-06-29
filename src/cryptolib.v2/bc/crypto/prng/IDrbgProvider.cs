using System;

using citronindo.cryptolib.bc.Crypto.Prng.Drbg;

namespace citronindo.cryptolib.bc.Crypto.Prng
{
    internal interface IDrbgProvider
    {
        ISP80090Drbg Get(IEntropySource entropySource);
    }
}
