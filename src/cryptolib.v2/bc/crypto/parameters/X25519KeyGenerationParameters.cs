using System;

using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Crypto.Parameters
{
    public class X25519KeyGenerationParameters
        : KeyGenerationParameters
    {
        public X25519KeyGenerationParameters(SecureRandom random)
            : base(random, 255)
        {
        }
    }
}
