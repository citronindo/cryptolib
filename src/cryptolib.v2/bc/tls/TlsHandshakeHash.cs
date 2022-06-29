﻿using System;
using System.IO;

using citronindo.cryptolib.bc.Tls.Crypto;

namespace citronindo.cryptolib.bc.Tls
{
    /// <summary>Base interface for an object that can calculate a handshake hash.</summary>
    public interface TlsHandshakeHash
        : TlsHash
    {
        /// <exception cref="IOException"/>
        void CopyBufferTo(Stream output);

        void ForceBuffering();

        void NotifyPrfDetermined();

        void TrackHashAlgorithm(int cryptoHashAlgorithm);

        void SealHashAlgorithms();

        void StopTracking();

        TlsHash ForkPrfHash();

        byte[] GetFinalHash(int cryptoHashAlgorithm);
    }
}
