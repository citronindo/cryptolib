﻿using System;

using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Crypto.Signers;

namespace citronindo.cryptolib.bc.Tls.Crypto.Impl.BC
{
    /// <summary>Implementation class for generation of the raw DSA signature type using the BC light-weight API.
    /// </summary>
    public class BcTlsDsaSigner
        : BcTlsDssSigner
    {
        public BcTlsDsaSigner(BcTlsCrypto crypto, DsaPrivateKeyParameters privateKey)
            : base(crypto, privateKey)
        {
        }

        protected override IDsa CreateDsaImpl(int cryptoHashAlgorithm)
        {
            return new DsaSigner(new HMacDsaKCalculator(m_crypto.CreateDigest(cryptoHashAlgorithm)));
        }

        protected override short SignatureAlgorithm
        {
            get { return Tls.SignatureAlgorithm.dsa; }
        }
    }
}
