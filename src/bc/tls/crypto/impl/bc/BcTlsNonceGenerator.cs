﻿using System;

using citronindo.cryptolib.bc.Crypto.Prng;

namespace citronindo.cryptolib.bc.Tls.Crypto.Impl.BC
{
    internal sealed class BcTlsNonceGenerator
        : TlsNonceGenerator
    {
        private readonly IRandomGenerator m_randomGenerator;

        internal BcTlsNonceGenerator(IRandomGenerator randomGenerator)
        {
            this.m_randomGenerator = randomGenerator;
        }

        public byte[] GenerateNonce(int size)
        {
            byte[] nonce = new byte[size];
            m_randomGenerator.NextBytes(nonce);
            return nonce;
        }
    }
}
