﻿using System;

using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Crypto.Generators
{
    public class Ed448KeyPairGenerator
        : IAsymmetricCipherKeyPairGenerator
    {
        private SecureRandom random;

        public virtual void Init(KeyGenerationParameters parameters)
        {
            this.random = parameters.Random;
        }

        public virtual AsymmetricCipherKeyPair GenerateKeyPair()
        {
            Ed448PrivateKeyParameters privateKey = new Ed448PrivateKeyParameters(random);
            Ed448PublicKeyParameters publicKey = privateKey.GeneratePublicKey();
            return new AsymmetricCipherKeyPair(publicKey, privateKey);
        }
    }
}
