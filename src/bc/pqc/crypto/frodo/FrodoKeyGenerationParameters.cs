
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Frodo
{
    public class FrodoKeyGenerationParameters
        : KeyGenerationParameters
    {
        private FrodoParameters parameters;

        public FrodoKeyGenerationParameters(
            SecureRandom random,
            FrodoParameters frodoParameters)
            : base(random, 256)
        {
            this.parameters = frodoParameters;
        }

        public FrodoParameters Parameters => parameters;
    }
}