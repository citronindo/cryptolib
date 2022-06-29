using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.SphincsPlus
{
    public class SPHINCSPlusKeyGenerationParameters
        : KeyGenerationParameters
    {
        private SPHINCSPlusParameters parameters;

        public SPHINCSPlusKeyGenerationParameters(SecureRandom random, SPHINCSPlusParameters parameters)
            : base(random, 256)
        {
            this.parameters = parameters;
        }

        internal SPHINCSPlusParameters Parameters => parameters;
    }
}