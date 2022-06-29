﻿using System;
using System.IO;

namespace citronindo.cryptolib.bc.Tls.Crypto
{
    public interface Tls13Verifier
    {
        /// <exception cref="IOException"/>
        Stream Stream { get; }

        /// <exception cref="IOException"/>
        bool VerifySignature(byte[] signature);
    }
}
