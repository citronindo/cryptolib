using System;

using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Crypto.Parameters
{
    public class Ed25519KeyGenerationParameters
        : KeyGenerationParameters
    {
        public Ed25519KeyGenerationParameters(SecureRandom random)
            : base(random, 256)
        {
        }
    }
}
