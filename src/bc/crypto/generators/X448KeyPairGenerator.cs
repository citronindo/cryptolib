using System;

using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Crypto.Generators
{
    public class X448KeyPairGenerator
        : IAsymmetricCipherKeyPairGenerator
    {
        private SecureRandom random;

        public virtual void Init(KeyGenerationParameters parameters)
        {
            this.random = parameters.Random;
        }

        public virtual AsymmetricCipherKeyPair GenerateKeyPair()
        {
            X448PrivateKeyParameters privateKey = new X448PrivateKeyParameters(random);
            X448PublicKeyParameters publicKey = privateKey.GeneratePublicKey();
            return new AsymmetricCipherKeyPair(publicKey, privateKey);
        }
    }
}
