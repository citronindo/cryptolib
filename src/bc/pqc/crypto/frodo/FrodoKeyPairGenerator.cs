
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Frodo
{
    public class FrodoKeyPairGenerator
        : IAsymmetricCipherKeyPairGenerator
    {
        private FrodoKeyGenerationParameters frodoParams;

        private int n;
        private int D;
        private int B;

        private SecureRandom random;

        private void Initialize(
            KeyGenerationParameters param)
        {
            frodoParams = (FrodoKeyGenerationParameters) param;
            random = param.Random;

            n = frodoParams.Parameters.N;
            D = frodoParams.Parameters.D;
            B = frodoParams.Parameters.B;
        }

        private AsymmetricCipherKeyPair GenKeyPair()
        {
            FrodoEngine engine = frodoParams.Parameters.Engine;
            byte[] sk = new byte[engine.PrivateKeySize];
            byte[] pk = new byte[engine.PublicKeySize];
            engine.kem_keypair(pk, sk, random);

            FrodoPublicKeyParameters pubKey = new FrodoPublicKeyParameters(frodoParams.Parameters, pk);
            FrodoPrivateKeyParameters privKey = new FrodoPrivateKeyParameters(frodoParams.Parameters, sk);
            return new AsymmetricCipherKeyPair(pubKey, privKey);
        }

        public void Init(KeyGenerationParameters param)
        {
            this.Initialize(param);
        }

        public AsymmetricCipherKeyPair GenerateKeyPair()
        {
            return GenKeyPair();
        }

    }
}