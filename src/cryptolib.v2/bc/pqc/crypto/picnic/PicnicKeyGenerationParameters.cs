using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Picnic
{
    public class PicnicKeyGenerationParameters
     : KeyGenerationParameters
    {
        private PicnicParameters parameters;

        public PicnicKeyGenerationParameters(SecureRandom random, PicnicParameters parameters)
            : base(random, 255)
        {
            this.parameters = parameters;
        }

        public PicnicParameters GetParameters()
        {
            return parameters;
        }
    }
}