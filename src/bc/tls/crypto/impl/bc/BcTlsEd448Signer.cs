﻿using System;

using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Crypto.Signers;

namespace citronindo.cryptolib.bc.Tls.Crypto.Impl.BC
{
    public class BcTlsEd448Signer
        : BcTlsSigner
    {
        public BcTlsEd448Signer(BcTlsCrypto crypto, Ed448PrivateKeyParameters privateKey)
            : base(crypto, privateKey)
        {
        }

        public override TlsStreamSigner GetStreamSigner(SignatureAndHashAlgorithm algorithm)
        {
            if (algorithm == null || SignatureScheme.From(algorithm) != SignatureScheme.ed448)
                throw new InvalidOperationException("Invalid algorithm: " + algorithm);

            Ed448Signer signer = new Ed448Signer(TlsUtilities.EmptyBytes);
            signer.Init(true, m_privateKey);

            return new BcTlsStreamSigner(signer);
        }
    }
}
