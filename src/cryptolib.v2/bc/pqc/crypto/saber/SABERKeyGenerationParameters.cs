
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Saber
{
    public class SABERKeyGenerationParameters
        : KeyGenerationParameters
    {
        private SABERParameters parameters;

        public SABERKeyGenerationParameters(
            SecureRandom random,
            SABERParameters saberParameters)
            : base(random, 256)
        {
            this.parameters = saberParameters;
        }

        public SABERParameters GetParameters()
        {
            return parameters;
        }
    }
}