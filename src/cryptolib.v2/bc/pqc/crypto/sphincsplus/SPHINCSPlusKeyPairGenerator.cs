
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.SphincsPlus
{
    public class SPHINCSPlusKeyPairGenerator
        : IAsymmetricCipherKeyPairGenerator
    {
        private SecureRandom random;
        private SPHINCSPlusParameters parameters;

        public void Init(KeyGenerationParameters param)
        {
            random = param.Random;
            parameters = ((SPHINCSPlusKeyGenerationParameters) param).Parameters;
        }

        public AsymmetricCipherKeyPair GenerateKeyPair()
        {
            SPHINCSPlusEngine engine = parameters.Engine;

            SK sk = new SK(SecRand(engine.N), SecRand(engine.N));
            byte[] pkSeed = SecRand(engine.N);
            // TODO
            PK pk = new PK(pkSeed, new HT(engine, sk.seed, pkSeed).HTPubKey);

            return new AsymmetricCipherKeyPair(new SPHINCSPlusPublicKeyParameters(parameters, pk),
                new SPHINCSPlusPrivateKeyParameters(parameters, sk, pk));
        }

        private byte[] SecRand(int n)
        {
            byte[] rv = new byte[n];

            random.NextBytes(rv);

            return rv;
        }
    }
}