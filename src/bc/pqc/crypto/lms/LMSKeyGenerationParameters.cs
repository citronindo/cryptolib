using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Lms
{

    public class LMSKeyGenerationParameters
        : KeyGenerationParameters
    {
        private LMSParameters lmsParameters;

        /**
         * Base constructor - parameters and a source of randomness.
         *
         * @param lmsParameters LMS parameter set to use.
         * @param random   the random byte source.
         */
        public LMSKeyGenerationParameters(LMSParameters lmsParameters, SecureRandom random)
            : base(random, LmsUtils.CalculateStrength(lmsParameters)) // TODO: need something for "strength"
        {
            this.lmsParameters = lmsParameters;
        }

        public LMSParameters GetParameters()
        {
            return lmsParameters;
        }
    }
}

