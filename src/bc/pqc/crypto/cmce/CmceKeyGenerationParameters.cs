using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Cmce
{
    public class CmceKeyGenerationParameters
        : KeyGenerationParameters
    {
        private CmceParameters parameters;

        public CmceKeyGenerationParameters(
            SecureRandom random,
            CmceParameters CmceParams)
            : base(random, 256)
        {
            this.parameters = CmceParams;
        }

        public CmceParameters Parameters => parameters;
    }
}