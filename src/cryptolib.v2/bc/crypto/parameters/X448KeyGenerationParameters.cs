using System;

using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Crypto.Parameters
{
    public class X448KeyGenerationParameters
        : KeyGenerationParameters
    {
        public X448KeyGenerationParameters(SecureRandom random)
            : base(random, 448)
        {
        }
    }
}
